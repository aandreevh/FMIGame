using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    using ItemBag = HashSet<Item>;
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private ItemBag items = new ItemBag();
        
        public ItemBag Items => items;

        public bool RemoveItem(Item item)
        {
            return  Items.Remove(item);
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public bool HasItem(Item item)
        {
            return Items.Contains(item);
        }

        public bool AllItemsIn(Inventory other)
        {
            foreach (var item in Items)
            {
                if (!other.HasItem(item)) return false;
            }

            return true;
        }
        
    
    }
}