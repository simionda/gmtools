using gmtools.rnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace gmtools.rolltables
{
    public class BaseRollTable
    {
        public string Name { get; internal set; }

        internal Dictionary<int, List<RollTableAction>> Table { get; set; } = new Dictionary<int, List<RollTableAction>>();

        private Die die;

        public RollTableResult Roll()
        {
            return Roll(new RollTableResult());
        }

        public RollTableResult Roll(RollTableResult result)
        {
            if (die == null || die.Sides != Table.Count)
            {
                die = new Die("1d" + Table.Count.ToString());
            }

            var roll = die.Roll();

            if (!Table.ContainsKey(roll))
            {
                throw new ArgumentOutOfRangeException($"Invalid entry '{roll}' for table");
            }

            foreach(var a in Table[roll])
            {
                result = a.Action(result);
            }

            return result;
        }

        public void AddTableEntry(int index, RollTableAction action, bool extendOnDuplicate = false)
        {
            if (Table.ContainsKey(index))
            {
                if (!extendOnDuplicate)
                {
                    throw new ArgumentOutOfRangeException($"Index '{index}' already exists in table and option to extend not enabled");
                }

                Table[index].Add(action);
            }

            Table.Add(index, new List<RollTableAction>() { action });
        }

        public void AddTableEntry(int index, IEnumerable<RollTableAction> action, bool extendOnDuplicate = false)
        {
            if (Table.ContainsKey(index))
            {
                if (!extendOnDuplicate)
                {
                    throw new ArgumentOutOfRangeException($"Index '{index}' already exists in table and option to extend not enabled");
                }

                Table[index].AddRange(action);
            }

            Table.Add(index, action.ToList());
        }

        public void AddTableEntry(int index, params RollTableAction[] action)
        {
            AddTableEntry(index, action.ToList(), false);
        }

        public void AddTableEntry(string indexRange, RollTableAction action, bool extendOnDuplicate = false)
        {
            ParseIndexRangeAndAddToTable(indexRange, (i) => AddTableEntry(i, action, extendOnDuplicate));
        }


        public void AddTableEntry(string indexRange, IEnumerable<RollTableAction> action, bool extendOnDuplicate = false)
        {
            ParseIndexRangeAndAddToTable(indexRange, (i) => AddTableEntry(i, action, extendOnDuplicate));
        }

        public void AddTableEntry(string indexRange, params RollTableAction[] action)
        {
            ParseIndexRangeAndAddToTable(indexRange, (i) => AddTableEntry(i, action.ToList(), false));
        }

        private void ParseIndexRangeAndAddToTable(string indexRange, Action<int> a)
        {
            //Remove all whitespace
            var temp = Regex.Replace(indexRange, @"\s+", "");

            //Ensure {int}-{int} format
            if (temp.IndexOf('-') == -1)
            {
                throw new ArgumentOutOfRangeException($"Index range not in valid format of 'lowerValue'-'upperValue'");
            }

            var lower = temp.Split('-')[0];
            var upper = temp.Split('-')[1];

            if (!int.TryParse(lower, out int lowerIndex))
            {
                throw new ArgumentOutOfRangeException($"Lower Index '{lower}' not a valid integer");
            }

            if (!int.TryParse(upper, out int upperIndex))
            {
                throw new ArgumentOutOfRangeException($"Upper Index '{upper}' not a valid integer");
            }

            //Execute passed in method to add to list
            for (var index = lowerIndex; index <= upperIndex; index++)
            {
                a(index);
            }
        }

        internal RollTableAction BuildStringAction(string name)
        {
            return new RollTableAction(name, (r) => { r.Temp += name; return r; });
        }

        internal RollTableAction BuildRollTableAction(string description, string tableName)
        {
            return new RollTableAction(description, (r) => { var t = TableFactory.GetTableByName(tableName); return t.Roll(r); });
        }
    }
}
