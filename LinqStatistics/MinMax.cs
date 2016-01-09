using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqStatistics
{
    public struct MinMax<T> where T : struct, IConvertible
    {
        public T Min { get; internal set; }

        public T Max { get; internal set; }
         
        public T Range { get; internal set; }
    }
}
