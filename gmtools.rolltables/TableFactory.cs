using gmtools.rolltables.settlements;
using System;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace gmtools.rolltables
{
    public static class TableFactory
    {
        private static Dictionary<string, BaseRollTable> tableCache = new Dictionary<string, BaseRollTable>();

        public static BaseRollTable GetTableByName(string tableName)
        {
            return (tableName.ToLower(CultureInfo.InvariantCulture)) switch
            {
                "settlements.racerelations" => new RaceRelations(),
                _ => throw new ArgumentException($"Invalid table name '{tableName}'"),
            };
        }

        public static BaseRollTable Load(string tableName)
        {
            if (tableCache.ContainsKey(tableName))
            {
                return tableCache[tableName];
            }

            //Find table file by name
            var import_table = JsonConvert.DeserializeObject<SerializedTable>(File.ReadAllText(@"e:\rolltables\" + tableName + ".json"));

            var table = new BaseRollTable();
            table.Name = import_table.Name;

            foreach(var r in import_table.Ranges)
            {
                var actions = new List<RollTableAction>();

                foreach (var a in r.Actions)
                {
                    actions.Add(a.Type.ToLower(CultureInfo.InvariantCulture) switch
                    {
                        "string" => table.BuildStringAction(a.Params[0]),
                        "rolltable" => table.BuildRollTableAction(a.Params[0], a.Params[1]),
                        _ => throw new ArgumentException($"Invalid roll action type '{a.Type}'")
                    });
                }

                table.AddTableEntry(r.Range, actions);
            }

            tableCache.Add(tableName, table);
            
            return table;
        }

        internal class SerializedTable
        {
            public string Name { get; set; }
            public SerializedRange[] Ranges { get; set; }

        }

        internal class SerializedRange
        {
            public string Range { get; set; }
            public SerializedAction[] Actions { get; set; }
        }

        internal class SerializedAction
        {
            public string Type { get; set; }
            public string[] Params { get; set; }
        }
    }
}
