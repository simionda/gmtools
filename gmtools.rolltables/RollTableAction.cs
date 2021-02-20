using System;

namespace gmtools.rolltables
{
    public class RollTableAction
    {
        public string Description { get; private set; }
        public Func<RollTableResult, RollTableResult> Action { get; private set; }

        public RollTableAction(string description, Func<RollTableResult, RollTableResult> action)
        {
            this.Description = description;
            this.Action = action;
        }
    }
}
