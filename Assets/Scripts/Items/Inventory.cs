using System;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    using ItemBag = List<Item>;
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private ItemBag items = new ItemBag();
        
        public ItemBag Items => items;

        public event Action OnInvetoryChanged;

        public bool RemoveItem(Item item)
        {
            var removed = Items.Remove(item);
            if (removed)
            {
                OnInvetoryChanged?.Invoke();
            }

            return removed;
        }

        public void AddItem(Item item)
        {
           if(!Items.Contains(item)) Items.Add(item);
            OnInvetoryChanged?.Invoke();
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