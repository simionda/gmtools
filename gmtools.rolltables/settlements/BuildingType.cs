using System.Collections.Generic;

namespace gmtools.rolltables.settlements
{
    public class BuildingType : BaseRollTable
    {
        public BuildingType()
        {
            this.Name = "Building Type";
            this.AddTableEntry("1-10", BuildStringAction("Residence: "), BuildRollTableAction("Residence Type", "settlements.residence"));
            this.AddTableEntry("11-12", BuildStringAction("Religious: "), BuildRollTableAction("Religious Building Type", "settlements.religiousbuilding"));
            this.AddTableEntry("13-15", BuildStringAction("Tavern: "), BuildRollTableAction("Tavern Type", "settlements.tavern"));
            this.AddTableEntry("16-17", BuildStringAction("Warehouse: "), BuildRollTableAction("Warehouse Type", "settlements.warehouse"));
            this.AddTableEntry("18-20", BuildStringAction("Shop: "), BuildRollTableAction("Shop Type", "settlements.shop"));
        }
    }
}
