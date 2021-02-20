namespace gmtools.rolltables.settlements
{
    public class Warehouse : BaseRollTable
    {
        public Warehouse()
        {
            this.Name = "Warehouse";
            this.AddTableEntry("1-4", BuildStringAction("Empty or abandoned"));
            this.AddTableEntry("5-6", BuildStringAction("Heavily guarded, expensive goods"));
            this.AddTableEntry("7-10", BuildStringAction("Cheap goods"));
            this.AddTableEntry("11-14", BuildStringAction("Bulk goods"));
            this.AddTableEntry(15, BuildStringAction("Live animals"));
            this.AddTableEntry("16-17", BuildStringAction("Weapons/armor"));
            this.AddTableEntry("18-19", BuildStringAction("Goods from a distant land"));
            this.AddTableEntry(20, BuildStringAction("Secret smuggler's den"));
        }
        

    }
}
