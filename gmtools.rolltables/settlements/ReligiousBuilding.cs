namespace gmtools.rolltables.settlements
{
    public class ReligiousBuilding : BaseRollTable
    {
        public ReligiousBuilding()
        {
            this.Name = "Religious Building";
            this.AddTableEntry("1-10", BuildStringAction("Temple to a good or neutral diety"));
            this.AddTableEntry("11-12", BuildStringAction("Temple to a false deity (run by charlatan priests)"));
            this.AddTableEntry(13, BuildStringAction("Home of ascetics"));
            this.AddTableEntry("14-15", BuildStringAction("Abandoned shrine"));
            this.AddTableEntry("16-17", BuildStringAction("Library dedicated to religious study"));
            this.AddTableEntry("18-20", BuildStringAction("Hidden shrine to a fiend or an evil deity"));
        }
    }
}
