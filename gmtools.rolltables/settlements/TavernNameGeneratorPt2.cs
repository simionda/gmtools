namespace gmtools.rolltables.settlements
{
    public class TavernNameGeneratorPt2 : BaseRollTable
    {
        public TavernNameGeneratorPt2()
        {
            this.Name = "Tavern Name Generator Pt2";
            this.AddTableEntry(1, BuildStringAction("Eel"));
            this.AddTableEntry(2, BuildStringAction("Dolphin"));
            this.AddTableEntry(3, BuildStringAction("Dwarf"));
            this.AddTableEntry(4, BuildStringAction("Pegasus"));
            this.AddTableEntry(5, BuildStringAction("Pony"));
            this.AddTableEntry(6, BuildStringAction("Rose"));
            this.AddTableEntry(7, BuildStringAction("Stag"));
            this.AddTableEntry(8, BuildStringAction("Wolf"));
            this.AddTableEntry(9, BuildStringAction("Lamb"));
            this.AddTableEntry(10, BuildStringAction("Demon"));
            this.AddTableEntry(11, BuildStringAction("Goat"));
            this.AddTableEntry(12, BuildStringAction("Spirit"));
            this.AddTableEntry(13, BuildStringAction("Horde"));
            this.AddTableEntry(14, BuildStringAction("Jester"));
            this.AddTableEntry(15, BuildStringAction("Mountain"));
            this.AddTableEntry(16, BuildStringAction("Eagle"));
            this.AddTableEntry(17, BuildStringAction("Satyr"));
            this.AddTableEntry(18, BuildStringAction("Dog"));
            this.AddTableEntry(19, BuildStringAction("Spider"));
            this.AddTableEntry(20, BuildStringAction("Star"));
        }
    }
}
