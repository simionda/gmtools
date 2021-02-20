namespace gmtools.rolltables.settlements
{
    public class Tavern : BaseRollTable
    {
        public Tavern()
        {
            this.Name = "Tavern";
            this.AddTableEntry("1-5", BuildTavernTypeAndName("Quiet, low-key bar"));
            this.AddTableEntry("6-9", BuildTavernTypeAndName("Raucous dive"));
            this.AddTableEntry(10, BuildTavernTypeAndName("Thieves' guild hangout"));
            this.AddTableEntry(11, BuildTavernTypeAndName("Gathering place for a secret society"));
            this.AddTableEntry("12-13", BuildTavernTypeAndName("Upper-class dining club"));
            this.AddTableEntry("14-15", BuildTavernTypeAndName("Gambling den"));
            this.AddTableEntry("16-17", BuildTavernTypeAndName("Place which caters to specific race or guild"));
            this.AddTableEntry(18, BuildTavernTypeAndName("Members-only club"));
            this.AddTableEntry("19-20", BuildTavernTypeAndName("Brothel"));
        }

        private RollTableAction[] BuildTavernTypeAndName(string name)
        {
            return new RollTableAction[] { BuildRollTableAction("Tavern Name Pt 1", "settlements.tavernnamegeneratorpt1"), BuildRollTableAction("Tavern Name Pt2", "settlements.tavernnamegeneratorpt2"), BuildStringAction(", a " + name),  };
        }
    }
}
