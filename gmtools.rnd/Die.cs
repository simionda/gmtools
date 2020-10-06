using System;
using gmtools.common;

namespace gmtools.rnd
{
    public class Die
    {
        public int Quantity { get; private set; }
        public int Sides { get; private set; }
        public int Additional { get; private set; }
        public int Multiplier { get; private set; }

        private readonly int _baseSeed = 0;
        private readonly Random rnd = new Random(Convert.ToInt32(DateTime.Now.Ticks % int.MaxValue));

        public Die(string display, int encounterId)
        {
            _baseSeed = encounterId;
            ParseDisplayValue(display);
        }

        public Die(string display)
        {
            ParseDisplayValue(display);
        }

        //Sets a 0D1+value to effectively roll the constant value
        public Die(int constant)
        {
            this.Quantity = 0;
            this.Sides = 1;
            this.Additional = constant - 1;
            this.Multiplier = 0;
        }

        public int Roll()
        {
            Logger.Log($"Rolling for {this.ToString()}");
            var result = 0;
            for (var ctr = 1; ctr <= Quantity; ctr++)
            {
                result += rnd.Next(1, Sides + 1);
                Logger.Log($"  {ctr} of {Quantity}, Current Total: {result}");
            }

            result += Additional;
            Logger.Log($"  After additional: {result}");
            result *= Multiplier;
            Logger.Log($"  After multiplier: {result}");

            return result;
        }

        private void ParseDisplayValue(string display)
        {
            //Dice String in format of [{qty}]D{sides}[+{additional}][x{multiplier}], valid examples: D8, 2D8, D8+1, 1D8+1, 2D8+2,2D6x10
            //Qty is positive integer. If it is missing from string, assumed to be 1
            //Sides is a positive integer. Required. For D&D, valid sides are 4, 6, 8, 10, 12, 20, and 100.
            //Additional is a positive integer. Value is optional but required in string if '+' exists. Defaults to 0.
            //Multiplier is a positive integer. Value is optional but required in string if 'x' exists. Defaults to 1.

            const string VALID_FORMAT = "Display value is not in a valid die format. Ex: D8, 2D8, 2D8+1, 2D8x5.";

            var dPos = display.IndexOf('D', StringComparison.InvariantCultureIgnoreCase);
            var plusPos = display.IndexOf('+');
            var timesPos = display.IndexOf('x');

            if (!DTokenIsPresent(dPos))
            {
                if (Int32.TryParse(display, out var constant))
                {
                    this.Quantity = 0;
                    this.Sides = 1;
                    this.Additional = constant;
                    this.Multiplier = 1;

                    return;
                }
                throw new ArgumentException(VALID_FORMAT, nameof(display));
            }

            if (PlusTokenIsPresent(plusPos) &&
                !PlusTokenIsAfterDTokenButNotLast(plusPos, dPos, display.Length)) throw new ArgumentException(VALID_FORMAT, nameof(display));
            if (TimesTokenIsPresent(timesPos) &&
                !TimesTokenIsAfterDTokenButNotLast(timesPos, dPos, display.Length)) throw new ArgumentException(VALID_FORMAT, nameof(display));

            //Get quantity from string
            switch (dPos)
            {
                //If no quantity before the 'D', assume qty = 1
                case 0:
                    this.Quantity = 1;
                    break;
                default:
                    //Extract the potential qty string - all characters between start and 'D'
                    var qtyStr = display.Substring(0, dPos);
                    if (int.TryParse(qtyStr, out var tmpQty))
                    {
                        this.Quantity = tmpQty;
                    }
                    else
                    {
                        throw new ArgumentException($"Display value contains an invalid quantity. [{qtyStr}]", nameof(display));
                    }

                    break;
            }

            //Get # of sides from string
            var sideStringLength = -1;
            if (PlusTokenIsPresent(plusPos))
            {
                sideStringLength = plusPos - dPos - 1;
            }
            if (TimesTokenIsPresent(timesPos))
            {
                sideStringLength = timesPos - dPos - 1;
            }
            if (sideStringLength == -1)
            {
                sideStringLength = display.Length - dPos - 1;
            }
            var sideStr = display.Substring(dPos + 1, sideStringLength);
            if (int.TryParse(sideStr, out var tmpSides))
            {
                this.Sides = tmpSides;
            }
            else
            {
                throw new ArgumentException($"Display value contains an invalid number of sides. [{sideStr}]", nameof(display));
            }

            //Get any additional values
            if (PlusTokenIsPresent(plusPos))
            {
                var plusStr = display.Substring(plusPos + 1, display.Length - plusPos - 1);
                if (int.TryParse(plusStr, out var tmpAdditional))
                {
                    this.Additional = tmpAdditional;
                }
                else
                {
                    throw new ArgumentException($"Display value contains an invalid additional value. [{plusStr}]", nameof(display));
                }
            }
            else
            {
                this.Additional = 0;
            }

            if (TimesTokenIsPresent(timesPos))
            {
                var timesStr = display.Substring(timesPos + 1, display.Length - timesPos - 1);
                if (int.TryParse(timesStr, out var tmpMultiplier))
                {
                    this.Multiplier = tmpMultiplier;
                }
                else
                {
                    throw new ArgumentException($"Display value contains an invalid multiplier value. [{timesStr}]", nameof(display));
                }
            }
            else
            {
                this.Multiplier = 1;
            }
        }

        private bool DTokenIsPresent(int dPosition)
        {
            return dPosition > -1;
        }

        private bool PlusTokenIsPresent(int plusPosition)
        {
            return plusPosition > -1;
        }

        private bool PlusTokenIsAfterDTokenButNotLast(int plusPosition, int dPosition, int stringLength)
        {
            return dPosition < plusPosition && plusPosition < stringLength - 1;
        }

        private bool TimesTokenIsPresent(int timesPosition)
        {
            return timesPosition > -1;
        }

        private bool TimesTokenIsAfterDTokenButNotLast(int timesPosition, int dPosition, int stringLength)
        {
            return dPosition < timesPosition && timesPosition < stringLength - 1;
        }

        public override string ToString()
        {
            var baseStr = $"{Quantity}d{Sides}";
            var addStr = $"+{Additional}";
            var multStr = $"x{Multiplier}";
            return Additional > 0 ? baseStr + addStr : Multiplier > 1 ? baseStr + multStr : baseStr;
        }

        public static Die D4 => new Die("1d4");
        public static Die D6 => new Die("1d6");
        public static Die D8 => new Die("1d8");
        public static Die D10 => new Die("1d10");
        public static Die D12 => new Die("1d12");
        public static Die D20 => new Die("1d20");
        public static Die D100 => new Die("1d100");
    }
}
