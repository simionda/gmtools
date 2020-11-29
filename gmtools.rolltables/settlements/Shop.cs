namespace gmtools.rolltables.settlements
{
    public class Shop : BaseRollTable
    {
        public Shop()
        {
            this.Name = "Shop";
            this.AddTableEntry(1, BuildStringAction("Pawnshop"));
            this.AddTableEntry(2, BuildStringAction("Herbs/incense"));
            this.AddTableEntry(3, BuildStringAction("Fruits/vegetables"));
            this.AddTableEntry(4, BuildStringAction("Dried meats"));
            this.AddTableEntry(5, BuildStringAction("Pottery"));
            this.AddTableEntry(6, BuildStringAction("Undertaker"));
            this.AddTableEntry(7, BuildStringAction("Books"));
            this.AddTableEntry(8, BuildStringAction("Moneylender"));
            this.AddTableEntry(9, BuildStringAction("Weapons/armor"));
            this.AddTableEntry(10, BuildStringAction("Chandler"));
            this.AddTableEntry(11, BuildStringAction("Smithy"));
            this.AddTableEntry(12, BuildStringAction("Carpenter"));
            this.AddTableEntry(13, BuildStringAction("Weaver"));
            this.AddTableEntry(14, BuildStringAction("Jeweler"));
            this.AddTableEntry(15, BuildStringAction("Baker"));
            this.AddTableEntry(16, BuildStringAction("Mapmaker"));
            this.AddTableEntry(17, BuildStringAction("Tailor"));
            this.AddTableEntry(18, BuildStringAction("Ropemaker"));
            this.AddTableEntry(19, BuildStringAction("Mason"));
            this.AddTableEntry(20, BuildStringAction("Scribe"));
        }
    }
}
