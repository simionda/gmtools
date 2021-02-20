using gmtools.rolltables.settlements;
using System;
using System.Globalization;

namespace gmtools.rolltables
{
    public static class TableFactory
    {
        public static BaseRollTable GetTableByName(string tableName)
        {
            return (tableName.ToLower(CultureInfo.InvariantCulture)) switch
            {
                "settlements.racerelations" => new RaceRelations(),
                "settlements.buildingtype" => new BuildingType(),
                "settlements.residence" => new Residence(),
                "settlements.religiousbuilding" => new ReligiousBuilding(),
                "settlements.tavern" => new Tavern(),
                "settlements.tavernnamegeneratorpt1" => new TavernNameGeneratorPt1(),
                "settlements.tavernnamegeneratorpt2" => new TavernNameGeneratorPt2(),
                "settlements.warehouse" => new Warehouse(),
                "settlements.shop" => new Shop(),
                _ => throw new ArgumentException($"Invalid table name '{tableName}'"),
            };
        }
    }
}
