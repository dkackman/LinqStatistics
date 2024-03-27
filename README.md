# LinqStatistics

[![.NET Core](https://github.com/dkackman/LinqStatistics/actions/workflows/dotnet-core.yml/badge.svg)](https://github.com/dkackman/LinqStatistics/actions/workflows/dotnet-core.yml)
[![NuGet](https://img.shields.io/nuget/dt/LinqStatistics)](https://www.nuget.org/packages/LinqStatistics/)

- [API Documentation](https://dkackman.github.io/LinqStatistics/)

Linq extensions to calculate basic statistics.

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

```csharp
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
```

## Older Versions

The latest version of this library target .NET 8 LTS. If you need to target older versions of .NET, you can find the appropriate version of this library on NuGet. [Version 2.3.0](https://www.nuget.org/packages/LinqStatistics/?version=2.3.0) targets .Net Standard 1.1 and .Net Framework 4.x.
