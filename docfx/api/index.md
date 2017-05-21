# LinqStatistics API

The LinqStatistics API is a set of extension methods that are modelled after
[Enumerable](xref:System.Linq.Enumerable), with overloads to accept the same intrinsic numeric types
as Sum and Average. TheLinqStatistics.NaN namespace includes implmentations that will
return [NaN](xref:System.Double.NaN) instead of throwing exceptions when cases like
divide by zero would happen.

## Statistics Included
### CountEach
[CountEach](xref:LinqStatistics.EnumerableStats.CountEach``1(System.Collections.Generic.IEnumerable{``0}))

### Covariance
[Covariance](xref:LinqStatistics.EnumerableStats.Covariance(System.Collections.Generic.IEnumerable{System.Decimal},System.Collections.Generic.IEnumerable{System.Decimal}))

![equation](~/images/covar.gif)

### Histogram
[Histogram](xref:LinqStatistics.EnumerableStats.Histogram(System.Collections.Generic.IEnumerable{System.Decimal},System.Int32,LinqStatistics.BinningMode))

### Kurtosis
[Kurtosis](xref:LinqStatistics.EnumerableStats.Kurtosis(System.Collections.Generic.IEnumerable{System.Decimal}))

![equation](~/images/kurtosis.gif)

### Least Squares Linear Regression
[Least Squares](xref:LinqStatistics.EnumerableStats.LeastSquares(System.Collections.Generic.IEnumerable{System.Tuple{System.Decimal,System.Decimal}}))

![equation](~/images/ls.gif)

![equation](~/images/ls_b.gif)

![equation](~/images/ls_m.gif)

### Median
[Median](xref:LinqStatistics.EnumerableStats.Median(System.Collections.Generic.IEnumerable{System.Decimal}))

### MinMax
[MinMax](xref:LinqStatistics.EnumerableStats.MinMax(System.Collections.Generic.IEnumerable{System.Decimal}))

### Mode
[Mode](xref:LinqStatistics.EnumerableStats.Mode``1(System.Collections.Generic.IEnumerable{``0}))

### Pearson
[Pearson](xref:LinqStatistics.EnumerableStats.Pearson(System.Collections.Generic.IEnumerable{System.Decimal},System.Collections.Generic.IEnumerable{System.Decimal}))

![equation](~/images/pearson.gif)

### Range
[Range](xref:LinqStatistics.EnumerableStats.Range(System.Collections.Generic.IEnumerable{System.Decimal}))

### Root Mean Square
[Root Mean Square](xref:LinqStatistics.EnumerableStats.RootMeanSquare(System.Collections.Generic.IEnumerable{System.Decimal}))

![equation](~/images/rms.gif)

### Skewness
[Skewness](xref:LinqStatistics.EnumerableStats.Skewness(System.Collections.Generic.IEnumerable{System.Decimal}))

![equation](~/images/skewness.gif)

### Standard Deviation
[Sample](xref:LinqStatistics.EnumerableStats.StandardDeviation(System.Collections.Generic.IEnumerable{System.Decimal}))

![equation](~/images/stdev.gif)

[Population](xref:LinqStatistics.EnumerableStats.StandardDeviationP(System.Collections.Generic.IEnumerable{System.Decimal}))

![equation](~/images/stdevp.gif)

### Variance
[Sample](xref:LinqStatistics.EnumerableStats.Variance(System.Collections.Generic.IEnumerable{System.Decimal}))

![equation](~/images/var.gif)

[Population](xref:LinqStatistics.EnumerableStats.VarianceP(System.Collections.Generic.IEnumerable{System.Decimal}))

![equation](~/images/varp.gif)
