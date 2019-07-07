using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LinqStatistics
{
    static class BinFactory
    {
        public static IEnumerable<Bin> CreateBins(double min, double max, int binCount, BinningMode mode)
        {
            if (binCount <= 0)
                throw new InvalidOperationException("binCount must be greater than 0");

            if (mode == BinningMode.Unbounded)
            {
                return CreateBinsUnbounded(min, max, binCount);
            }

            if (mode == BinningMode.ExpandRange)
            {
                return CreateBinsExpandRange(min, max, binCount);
            }

            Debug.Assert(mode == BinningMode.MaxValueInclusive);
            return CreateBinsMaxInclusive(min, max, binCount);
        }

        private static IEnumerable<Bin> CreateBinsMaxInclusive(double min, double max, int binCount)
        {
            double binSize = (max - min) / binCount;
            double halfBin = binSize / 2.0;
            double rangeMin = min;
            double rangeMax = rangeMin + binSize;

            // first create a list of all the bins so even empty bins are accounted for
            List<Bin> bins = new List<Bin>(binCount);
            for (int i = 0; i < binCount; i++)
            {
                if (i == binCount - 1)
                {
                    // we can get some floating point noise as the ranges are calculated to ensure that the last bin encompasses the max value
                    bins.Add(new Bin(rangeMin + halfBin, rangeMin, max, true)); // set the last bin to be maxInclusive
                }
                else
                {
                    bins.Add(new Bin(rangeMin + halfBin, rangeMin, rangeMax));
                }
                rangeMin += binSize;
                rangeMax += binSize;
            }

            return bins;
        }

        private static IEnumerable<Bin> CreateBinsUnbounded(double min, double max, int binCount)
        {
            double binSize = (max - min) / binCount;
            double halfBin = binSize / 2.0;
            double rangeMin = min;
            double rangeMax = rangeMin + binSize;

            // first create a list of all the bins so even empty bins are accounted for
            List<Bin> bins = new List<Bin>(binCount);
            for (int i = 0; i < binCount; i++)
            {
                bins.Add(new Bin(rangeMin + halfBin, rangeMin, rangeMax));
                rangeMin += binSize;
                rangeMax += binSize;
            }

            // sequence behavior is an unbounded histogram so add a bin for [lastBin.Range.Max, Infinity)
            bins.Add(new Bin(rangeMin + halfBin, rangeMin, double.PositiveInfinity));

            return bins;
        }

        private static IEnumerable<Bin> CreateBinsExpandRange(double min, double max, int binCount)
        {
            double binSize = (max - min) / ((double)binCount - 1);  // make the range such that the min and max are outside of the data set 
                                                                    // that's where the minus one comes in
            double halfBin = binSize / 2.0;
            double rangeMin = min - halfBin;
            double rangeMax = rangeMin + binSize;

            // first create a list of all the bins so even empty bins are accounted for
            List<Bin> bins = new List<Bin>(binCount);
            for (int i = 0; i < binCount; i++)
            {
                bins.Add(new Bin(rangeMin + halfBin, rangeMin, rangeMax));
                rangeMin += binSize;
                rangeMax += binSize;
            }

            return bins;
        }
    }
}
