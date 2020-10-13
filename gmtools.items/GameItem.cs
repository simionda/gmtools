namespace gmtools.items
{
    public class GameItem
    {
        public string Name { get; private set; }
        public ItemCategory Category { get; private set; }
        public int BaseQty { get; private set; }
        public string BaseCost { get; private set; }

        public GameItem(string name, ItemCategory category, int baseQty, string baseCost)
        {
            this.Name = Name;
            this.Category = category;
            this.BaseQty = baseQty;
            this.BaseCost = baseCost;
        }
    }
}
