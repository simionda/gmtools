using System;

namespace gmtools.time.Calendars
{
    public class Harptos : GameCalendar
    {
        //Temporary
        private decimal ticks = 0.0m; 

        /* Base Constants :: Start */
        private const int SECONDS_PER_DAY = 86400;
        private const int SECONDS_PER_ROUND = 6;
        private const int SECONDS_PER_MINUTE = 60;
        private const int SECONDS_PER_HOUR = 3600;
        private const int MINUTES_PER_HOUR = 60;
        private const int MINUTES_PER_DAY = 1440;
        private const int HOURS_PER_DAY = 24;

        private const decimal MIDNIGHT = 0.0m;

        private const int EPOCH_YEAR = 0;
        private const int DAYS_PER_YEAR = 365;
        private const int YEARS_PER_LEAPYEAR = 4;

        public readonly string[] MonthNamesCommon = { "The Rotting", "The Drawing Down" };
        public readonly string[] HolidayNames = { "Midwinter", "Greengrass", "Midsummer", "Shieldmeet", "Highharvestide", "The Feast of the Moon" };
        /* Base Constants :: End */

        /* Constant Lookups :: Start */
        private const decimal TICKS_PER_SECOND = 1.0m / SECONDS_PER_DAY;
        private const decimal TICKS_PER_ROUND = TICKS_PER_SECOND * SECONDS_PER_ROUND;
        private const decimal TICKS_PER_MINUTE = TICKS_PER_SECOND * SECONDS_PER_MINUTE;
        private const decimal TICKS_PER_HOUR = TICKS_PER_SECOND * SECONDS_PER_HOUR;
        private const decimal TICKS_PER_DAY = TICKS_PER_SECOND * SECONDS_PER_DAY;
        /* Constant Lookups :: End */

        public Harptos()
        {
            this.Name = "Harptos";
            this.DaysPerYear = 365;
            this.Definition = new CalendarDefinitionItem[]
            {
                new CalendarDefinitionItem("Hammer", "Deepwinter", 1, 30 ),
                new CalendarDefinitionItem("Midwinter", "", 31, 31 ),
                new CalendarDefinitionItem("Alturiak", "The Claw of Winter", 32, 61 ),
                new CalendarDefinitionItem("Ches", "The Claw of Sunsets", 62, 91 ),
                new CalendarDefinitionItem("Tarsahk", "The Claw of Storms", 92, 121 ),
                new CalendarDefinitionItem("Greengrass", "", 122, 122 ),
                new CalendarDefinitionItem("Mirtul", "The Melting", 123, 152 ),
                new CalendarDefinitionItem("Kythorn", "The Time of Flowers", 153, 182 ),
                new CalendarDefinitionItem("Flamerule", "Summertide", 183, 212 ),
                new CalendarDefinitionItem("Midsummer", "", 213, 213 ),
                new CalendarDefinitionItem("Eleasis", "Highsun", 214, 243 ),
                new CalendarDefinitionItem("Elient", "The Fading", 244, 273 ),
                new CalendarDefinitionItem("Highharvestide", "", 274, 274 ),
                new CalendarDefinitionItem("Marpenoth", "Leaffall", 275, 304 ),
                new CalendarDefinitionItem("Uktar", "The Rotting", 305, 334 ),
                new CalendarDefinitionItem("The Feast of the Moon", "", 335, 335 ),
                new CalendarDefinitionItem("Nightal", "The Drawing Down", 336, 365 )
            };

            ticks = MIDNIGHT;
        }

        public Harptos(decimal ticks)
        {
            this.ticks = ticks;
        }

        public Harptos(int hour, int minute, int second)
        {
            VerifyParameterValue(hour, HOURS_PER_DAY, "Hour");
            VerifyParameterValue(minute, MINUTES_PER_HOUR, "Minute");
            VerifyParameterValue(second, SECONDS_PER_MINUTE, "Seconds");

            ticks += hour * TICKS_PER_HOUR;
            ticks += minute * TICKS_PER_MINUTE;
            ticks += second * TICKS_PER_SECOND;
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
            ticks += TICKS_PER_SECOND;
        }

        public void AddRound()
        {
            ticks += TICKS_PER_ROUND;
        }

        public override string ToString()
        {
            var itd = new InternalDateTime(ticks);
            return $"{itd.Hour}:{itd.Minute}:{itd.Seconds}";
        }

        private struct InternalDateTime
        {
            public int Year { get; private set; }
            public int Month { get; private set; }
            public int Holiday { get; private set; }
            public int Day { get; private set; }
            public int Hour { get; private set; }
            public int Minute { get; private set; }
            public int Seconds { get; private set; }

            public InternalDateTime(decimal ticks)
            {
                var dateTicks = Convert.ToInt32(Math.Floor(ticks));
                var timeTicks = ticks - dateTicks;

                Year = EPOCH_YEAR;
                Month = 1;
                Holiday = 0;
                Day = 1;

                Hour = 0;
                Minute = 0;
                Seconds = 0;

                CalculateDate(dateTicks);
                CalculateTime(timeTicks);
            }

            private void CalculateDate(int dateTicks)
            {
                Year = Convert.ToInt32(dateTicks / DAYS_PER_YEAR) + EPOCH_YEAR;

                if (Year > 0)
                {
                    dateTicks %= Year * DAYS_PER_YEAR;
                }

                if (dateTicks == 0)
                {
                    Month = 1;
                    Holiday = 0;
                    Day = 1;
                    return;
                }

                switch (dateTicks)
                {
                    case int n when n <= 30:
                        SetMonth(1);
                        Day = n;
                        break;
                    case int n when n == 31:
                        SetHoliday(1);
                        Day = 31;
                        break;
                    case int n when n > 31 && n <= 61:
                        SetMonth(2);
                        Day = n - 31;
                        break;
                    default:
                        Month = 1;
                        Holiday = 0;
                        Day = 1;
                        break;
                }
            }

            private void SetMonth(int monthNumber)
            {
                Month = monthNumber;
                Holiday = 0;
            }

            private void SetHoliday(int holidayNumber)
            {
                Month = 0;
                Holiday = holidayNumber;
            }

            private void CalculateTime(decimal timeTicks)
            {
                var tmp = timeTicks;
                if (tmp == 0.0m)
                {
                    Hour = 0;
                    Minute = 0;
                    Seconds = 0;
                    return;
                }

                Hour = Convert.ToInt32(Math.Floor(tmp / TICKS_PER_HOUR));
                if (Hour > 0)
                {
                    tmp %= Hour * TICKS_PER_HOUR;
                }

                if (tmp == 0.0m)
                {
                    Minute = 0;
                    Seconds = 0;
                    return;
                }

                Minute = Convert.ToInt32(Math.Floor(tmp / TICKS_PER_MINUTE));

                if (Minute > 0)
                {
                    tmp %= Minute * TICKS_PER_MINUTE;
                }

                Seconds = Convert.ToInt32(tmp / TICKS_PER_SECOND);
            }
        }
    }
}
