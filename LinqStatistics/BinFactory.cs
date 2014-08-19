using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqStatistics
{
    static class BinFactory
    {
        public static IList<Bin> CreateBins(double min, double max, int binCount, BinningMode mode)
        {
            if (mode == BinningMode.Unbounded)
            {
                return CreateBinsUnbounded(min, max, binCount);
            }

            if (mode == BinningMode.ExpandRange)
            {
                return CreateBinsExpandRange(min, max, binCount);
            }

            return null;
        }

        private static IList<Bin> CreateBinsUnbounded(double min, double max, int binCount)
        {
            if (binCount <= 0)
                throw new InvalidOperationException("binCount must be greater than 0");

            double binSize = (max - min) / (double)binCount;
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

            // if sequence behavior is an unbounded histogram so add a bin for [lastBin.Range.Max, Infinity)
            bins.Add(new Bin(rangeMin + halfBin, rangeMin, double.PositiveInfinity));

            return bins;
        }

        private static IList<Bin> CreateBinsExpandRange(double min, double max, int binCount)
        {
            if (binCount <= 0)
                throw new InvalidOperationException("binCount must be greater than 0");

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
