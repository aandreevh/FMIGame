using Items;
using UnityEngine;

namespace Signals.Emitters
{
    [RequireComponent(typeof(Inventory))]
    public class InventoryInteractSignal : InteractSignal
    {
        public Inventory Inventory { get; set; }

        private void Awake()
        {
            Inventory = GetComponent<Inventory>();
        }

        protected override bool MeetsRequirements(GameObject other)
        {
            var otherInventory = other.GetComponent<Inventory>();
            var meetsRequirements = !otherInventory.Equals(null) && Inventory.AllItemsIn(otherInventory);

            return meetsRequirements;
        }
    }
}