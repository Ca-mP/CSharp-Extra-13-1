using System.Runtime.CompilerServices;

namespace InventoryMaintenance
{
    public class InventoryItemList
    {
        private List<InventoryItem> items;

        public event ChangeHandler changed;

        public delegate void ChangeHandler(InventoryItemList list);

        public InventoryItemList()
        {
            items = new List<InventoryItem>();
        }

        public int Count => items.Count;

        public InventoryItem this[int i] 
        {
            get
            {
                if (i > items.Capacity)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return items[i];
                }
            }

            set
            {
                if (i > items.Capacity)
                {
                    items[i] = value;
                }
            }

        }

        public static InventoryItemList operator +(InventoryItemList list, InventoryItem item)
        {
            list.Add(item);
            
            return list;
        }

        public static InventoryItemList operator -(InventoryItemList list, InventoryItem item)
        {
            list.Remove(item);
            return list;
        }

        public void Add(InventoryItem item) => items.Add(item);

        public void Add(int itemNo, string description, decimal price)
        {
            InventoryItem i = new(itemNo, description, price);
            items.Add(i);
        }

        public void Remove(InventoryItem item) => items.Remove(item);

        public void Fill() => items = InventoryDB.GetItems();

        public void Save() => InventoryDB.SaveItems(items);
    }
}
