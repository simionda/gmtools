using System;
using System.Collections.Generic;
using System.Text;

namespace gmtools.items
{
    public interface IItemRepository
    {
        IEnumerable<GameItem> ItemList();
    }
}
