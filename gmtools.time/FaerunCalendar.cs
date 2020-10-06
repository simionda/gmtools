using System;
using System.ComponentModel.Design;
using System.Dynamic;

namespace gmtools.time
{
    public class FaerunCalendar : BaseTime
    {
        /* Base Constants :: Start */
        private const int SECONDS_PER_DAY = 86400;
        private const int SECONDS_PER_ROUND = 6;
        private const int SECONDS_PER_MINUTE = 60;
        private const int SECONDS_PER_HOUR = 3600;
        private const int MINUTES_PER_HOUR = 60;
        private const int MINUTES_PER_DAY = 1440;
        private const int HOURS_PER_DAY = 24;

        private const decimal MIDNIGHT = 0.0m;
        /* Base Constants :: End */

        /* Constant Lookups :: Start */
        private const decimal TICKS_PER_SECOND = (1.0m / SECONDS_PER_DAY);
        private const decimal TICKS_PER_ROUND = TICKS_PER_SECOND * SECONDS_PER_ROUND;
        private const decimal TICKS_PER_MINUTE = TICKS_PER_SECOND * SECONDS_PER_MINUTE;
        private const decimal TICKS_PER_HOUR = TICKS_PER_SECOND * SECONDS_PER_HOUR;
        private const decimal TICKS_PER_DAY = TICKS_PER_SECOND * SECONDS_PER_DAY;
        /* Constant Lookups :: End */

        public FaerunCalendar()
        {
            this.ticks = MIDNIGHT;
        }

        public FaerunCalendar(decimal ticks)
        {
            this.ticks = ticks;
        }

        public FaerunCalendar(int hour, int minute, int second)
        {
            VerifyParameterValue(hour, HOURS_PER_DAY, "Hour");
            VerifyParameterValue(minute, MINUTES_PER_HOUR, "Minute");
            VerifyParameterValue(second, SECONDS_PER_MINUTE, "Seconds");

            this.ticks += hour * TICKS_PER_HOUR;
            this.ticks += minute * TICKS_PER_MINUTE;
            this.ticks += second * TICKS_PER_SECOND;
        }

        private void VerifyParameterValue(int paramActual, int paramMax, string paramName)
        {
            if (paramActual < 0 || paramActual > paramMax)
            {
                throw new ArgumentOutOfRangeException(paramName, paramActual, $"{paramName} must be between 0 and {paramMax}");
            }
        }

        public void AddSecond()
        {
            this.ticks += TICKS_PER_SECOND;
        }

        public void AddRound()
        {
            this.ticks += TICKS_PER_ROUND;
        }

        public override string ToString()
        {
            var itd = new InternalDateTime(this.ticks);
            return $"{itd.Hour}:{itd.Minute}:{itd.Seconds}";
        }

        private struct InternalDateTime
        {
            public int Year { get; }
            public int Month { get; }
            public int Day { get;  }
            public int Hour { get; }
            public int Minute { get; }
            public int Seconds { get; }

            public InternalDateTime(decimal ticks)
            {
                this.Year = 0;
                this.Month = 1;
                this.Day = 1;

                var tmp = ticks;
                if (tmp == 0.0m)
                {
                    this.Hour = 0;
                    this.Minute = 0;
                    this.Seconds = 0;
                    return;
                }

                this.Hour = Convert.ToInt32(Math.Floor(tmp / TICKS_PER_HOUR));
                if (this.Hour > 0)
                {
                    tmp %= (this.Hour * TICKS_PER_HOUR);
                }

                if (tmp == 0.0m)
                {
                    this.Minute = 0;
                    this.Seconds = 0;
                    return;
                }

                this.Minute = Convert.ToInt32(Math.Floor(tmp / TICKS_PER_MINUTE));

                if (this.Minute > 0)
                {
                    tmp %= (this.Minute * TICKS_PER_MINUTE);
                }               

                this.Seconds = Convert.ToInt32(tmp / TICKS_PER_SECOND);
            }
        }
    }
}
