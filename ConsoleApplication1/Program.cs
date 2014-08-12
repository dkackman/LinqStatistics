using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

using LinqStatistics;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bitmap = (Bitmap)Bitmap.FromFile(@"d:\temp\test.bmp"))
            {
                // first get the pixel data (the bitmap above is 24bit, change as appropriate for the format)
                var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                byte[] buffer = new byte[data.Stride * data.Height];
                Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);
                bitmap.UnlockBits(data);

                List<int> colors = new List<int>();

                // now pack every three bytes (3 because we have a 24 bit format (no alpha)) in an int
                // this int will represent that color in a numeric format
                for (int i = 0; i < buffer.Length; i += 3)
                {
                    // each row stores Blue, Green, Red
                    Color c = Color.FromArgb(buffer[i + 2], buffer[i + 1], buffer[i]);
                    colors.Add(c.ToArgb());
                }

                int? mode = colors.Mode<int>();
                if (mode.HasValue)
                {
                    Color color = Color.FromArgb(mode.Value);
                    Console.WriteLine("Modal colors is R={0}, G={1}, B={2}", color.R, color.G, color.B);
                }
                else
                {
                    Console.WriteLine("No modal color");
                }

                var histogram = colors.CountEach();

                Console.WriteLine("");

                // a histogram is typically ordered by the value for graphing purposes
                // order it by count to display most common to least common colors
                foreach (Bin<int> bin in histogram.OrderByDescending(b => b.Count))
                {
                    Color color = Color.FromArgb(bin.RepresentativeValue);
                    Console.WriteLine("R={0}, G={1}, B={2} appears {3} times", color.R, color.G, color.B, bin.Count);
                }
            }
        }
    }
}
