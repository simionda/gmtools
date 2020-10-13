namespace gmtools.items
{
    public class ItemCategory
    {
        public string Name { get; private set; }
        public string SubCategory { get; private set; }

        public ItemCategory(string name, string subCategory)
        {
            this.Name = name;
            this.SubCategory = subCategory;
        }
    }
}
