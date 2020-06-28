using System;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Inventory))]
    public class ItemPicker : MonoBehaviour
    {
        
        private Inventory Inventory { get; set; }

        private void Awake()
        {
            Inventory = GetComponent<Inventory>();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
      
            var stack = other.gameObject.GetComponent<ItemStack>();
            if (stack)
            {
                stack.PickUp(Inventory);
            }
        }
    }
}