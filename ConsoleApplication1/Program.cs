using System;
using System.Collections.Generic;
using System.Linq;
using LinqStatistics;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> data = new int[] { 1, 2, 5, 6, 6, 8, 9, 9, 9 };

            Console.WriteLine("Count = {0}", data.Count());
            Console.WriteLine("Average = {0}", data.Average());
            Console.WriteLine("Median = {0}", data.Median());
            Console.WriteLine("Mode = {0}", data.Mode());
            Console.WriteLine("Sample Variance = {0}", data.Variance());
            Console.WriteLine("Sample Standard Deviation = {0}", data.StandardDeviation());
            Console.WriteLine("Population Variance = {0}", data.VarianceP());
            Console.WriteLine("Population Standard Deviation = {0}", data.StandardDeviationP());
            Console.WriteLine("Range = {0}", data.Range());
        }
    }
}
