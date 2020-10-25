namespace gmtools.time
{
    public abstract class GameCalendar
    {
        public virtual string Name { get; internal set; }

        public int DaysPerYear { get; internal set; }

        public CalendarDefinitionItem[] Definition { get; internal set; }

        public GameDateTime ParseTicks(decimal ticks)
        {
            return new GameDateTime();
        }
    }
}
