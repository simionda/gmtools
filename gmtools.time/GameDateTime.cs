using System;

namespace gmtools.time
{
    public class GameDateTime
    {
        internal decimal ticks;

        public decimal Ticks => ticks;
        public int Date => Convert.ToInt32(ticks);
        public decimal Time => ticks - Convert.ToInt32(ticks);
    }
}
