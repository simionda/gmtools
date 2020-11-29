namespace gmtools.rolltables.settlements
{
    public class RaceRelations : BaseRollTable
    {
        public RaceRelations()
        {
            this.Name = "Race Relations";

            this.AddTableEntry("1-10", BuildStringAction("Harmony"));
            this.AddTableEntry("11-14", BuildStringAction("Tension or rivalry"));
            this.AddTableEntry("15-16", BuildStringAction("Racial majority are conquerors"));
            this.AddTableEntry(17, BuildStringAction("Racial minority are rulers"));
            this.AddTableEntry(18, BuildStringAction("Racial minority are refugees"));
            this.AddTableEntry(19, BuildStringAction("Racial majority oppresses minority"));
            this.AddTableEntry(20, BuildStringAction("Racial minority oppresses majority"));
        }
    }
}
