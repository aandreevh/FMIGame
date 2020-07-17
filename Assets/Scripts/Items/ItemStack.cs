using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ItemStack : MonoBehaviour
    {
        [SerializeField] private Item item;
      
        public Item Item => item;
        
        private void Awake()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            if (Item)
                GetComponent<SpriteRenderer>().sprite = Item.Image;
            else
                GetComponent<SpriteRenderer>().sprite = null;
        }

        public void PickUp(Inventory inventory)
        {
            inventory.AddItem(Item);
            Destroy(gameObject);
        }
    }
}