using System;
using Items;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        
        public Inventory Inventory => inventory;
        private GridLayoutGroup Group { get; set; }

        private void Awake()
        {
            Inventory.OnInventoryChanged += UpdateItems;
            Group = GetComponent<GridLayoutGroup>();
        }

        private void UpdateItems()
        {
            ClearChildren();
            CreateItems();
        }

        private void CreateItems()
        {
            foreach (var item in Inventory.Items) CreateItem(item);
            UpdateSize();
        }

        private void CreateItem(Item item)
        {
            var empty = Instantiate(new GameObject(), transform, true);
            empty.AddComponent<Button>();
            empty.AddComponent<Image>().sprite = item.Image;
        }

        private void UpdateSize()
        {
            var count = Inventory.Items.Count;
            var size = count * Group.cellSize.x + Math.Max(count - 1, 0) * Group.spacing.x;
            var rectTransform = GetComponent<RectTransform>();
            var curDelta = rectTransform.sizeDelta;
            
            rectTransform.sizeDelta = new Vector2(size, curDelta.y);
        }

        private void ClearChildren()
        {
            foreach (Transform child in transform) Destroy(child.gameObject);
        }
    }
}