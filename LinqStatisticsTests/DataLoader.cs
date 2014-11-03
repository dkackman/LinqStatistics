using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace LinqStatistics.UnitTests
{
    static class DataLoader
    {
        public static IEnumerable<T> LoadData<T>(string name, Func<string, T> convert)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LinqStatistics.UnitTests." + name))
            using (StreamReader reader = new StreamReader(stream))
            {
                var list = new List<T>();
                string line = reader.ReadLine();
                while (line != null)
                {
                    list.Add(convert(line));
                    line = reader.ReadLine();
                }
                return list;
            }
        }
    }
}
