LinqStatistics
==============

[![NuGet](https://img.shields.io/nuget/dt/chia-dotnet)](https://www.nuget.org/packages/LinqStatistics/)

- [API Documentation](https://dkackman.github.io/LinqStatistics/)
- [Background](http://www.codeproject.com/Articles/42492/Using-LINQ-to-Calculate-Basic-Statistics)

Linq extensions to calculate basic statistics

Extension methods to compute basic statistics modeled after Enumerable.Average. Stats include:

- Covariance
- Median
- Mode
- Pearson's Correlation Coefficient
- Range
- Standard Deviation (sample and population)
- Variance (sample and population)
- Root Mean Square
- Least Squares Linear Regression
- CountEach
- Histogram

Basic usage looks like:

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
