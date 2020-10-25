namespace gmtools.time
{
    public class CalendarDefinitionItem
    {
        public string FormalName { get; private set; }
        public string CommonName { get; private set; }
        public int StartDayNumber { get; private set; }
        public int EndDayNumber { get; private set; }

        public CalendarDefinitionItem(string formalName, string commonName, int startDayNumber, int endDayNumber)
        {
            this.FormalName = formalName;
            this.CommonName = commonName;
            this.StartDayNumber = startDayNumber;
            this.EndDayNumber = endDayNumber;
        }
    }
}
