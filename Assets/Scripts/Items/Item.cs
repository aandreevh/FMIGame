using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Item")]
    public class Item : ScriptableObject
    {
        [SerializeField]
        private Sprite image;
        public Sprite Image => image;

        [SerializeField] private ItemRarity rarity;
        public ItemRarity Rarity => rarity;

        [SerializeField] private string itemName;
        public string Name => itemName;

        public string DecoratedName => string.Format("<b><color={0}>{1}</color></b>",Rarity.GetColor(),Name);

    }
}
