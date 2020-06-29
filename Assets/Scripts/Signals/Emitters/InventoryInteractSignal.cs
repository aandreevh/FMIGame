using Items;
using Popup;
using UnityEngine;

namespace Signals.Emitters
{
    [RequireComponent(typeof(Inventory))]
    public class InventoryInteractSignal : InteractSignal
    {
        [SerializeField] private GameObject popupObject;
        private GameObject PopupObject => popupObject;
        
        [SerializeField] private Transform popupPivot;
        private Vector3 PopupPosition => popupPivot.position;
        
        [SerializeField] private bool popupVisible = false;
        private bool PopupVisible
        {
            get => popupVisible;
            set => popupVisible = value;
        }

        [SerializeField] private float popupTimeout;
        public float PopupTimeout => popupTimeout;
        
        private Inventory Inventory { get; set; }

        private  void Awake()
        {
            Inventory = GetComponent<Inventory>();
        }

        protected override bool MeetsRequirements(GameObject other)
        {
            var otherInventory = other.GetComponent<Inventory>();
            bool meetsRequirements = (!otherInventory.Equals(null)) && Inventory.AllItemsIn(otherInventory);
           if(!meetsRequirements) CreatePopup(otherInventory);
            
            return meetsRequirements ;
        }

        private void CreatePopup(Inventory inventory)
        {
            if(PopupVisible) return;
            if (!PopupObject) return;

            GameObject newPopup = Instantiate(PopupObject);
            TextPopup popup = newPopup.GetComponent<TextPopup>();
            popup.HideTimeout = PopupTimeout;
            popup.transform.position = PopupPosition;
            popup.Text = UpdatePopupText(inventory);
            popup.OnPopup += SwitchPopup;
            popup.OnHide += SwitchPopup;
        }

        private string UpdatePopupText(Inventory inventory)
        {
            string s = "Items Needed:\n";
            foreach (var item in Inventory.Items)
            {
                if (!inventory.HasItem(item))
                {
                    s += item.DecoratedName + "\n";
                }
            }

            return s;
        }

        private void SwitchPopup()
        {
            PopupVisible = !PopupVisible;
        }
    }
}