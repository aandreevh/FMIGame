using Items;
using Signals.Emitters;
using UnityEngine;

namespace Popup
{
    [RequireComponent(typeof(InventoryInteractSignal))]
    public class InventoryRequiredPopup : ShowedPopup
    {
        [SerializeField] private Vector3 offset;

        private InventoryInteractSignal InventoryInteractComponent { get; set; }
        private Vector3 Offset => offset;

        private void Awake()
        {
            InventoryInteractComponent = GetComponent<InventoryInteractSignal>();
            InventoryInteractComponent.OnFailed += FailedRoutine;
        }

        private void CreatePopup(Inventory inventory)
        {
            ShowPopup(transform.position + Offset, UpdatePopupText(inventory));
        }

        private string UpdatePopupText(Inventory inventory)
        {
            var description = "Items Needed:\n";
            
            foreach (var item in InventoryInteractComponent.Inventory.Items)
                if (!inventory.HasItem(item))
                    description += item.DecoratedName + "\n";

            return description;
        }

        private void FailedRoutine(GameObject other)
        {
            var otherInventory = other.GetComponent<Inventory>();
            if (otherInventory) CreatePopup(otherInventory);
        }
    }
}