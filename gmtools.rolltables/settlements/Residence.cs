using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmtools.rolltables.settlements
{
    public class Residence : BaseRollTable
    {
        public Residence()
        {
            this.Name = "Residence";
            this.AddTableEntry("1-2", BuildStringAction("Abandoned squat"));
            this.AddTableEntry("3-8", BuildStringAction("Middle-class home"));
            this.AddTableEntry("9-10", BuildStringAction("Upper-class home"));
            this.AddTableEntry("11-15", BuildStringAction("Crowded tenement"));
            this.AddTableEntry("16-17", BuildStringAction("Orphanage"));
            this.AddTableEntry(18, BuildStringAction("Hidden slavers' den"));
            this.AddTableEntry(19, BuildStringAction("Front for a secret cult"));
            this.AddTableEntry(20, BuildStringAction("Lavish, guarded mansion"));
        }
    }
}
