using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private Sprite image;

        [SerializeField] private string itemName;

        [SerializeField] private ItemRarity rarity;
        public Sprite Image => image;
        public ItemRarity Rarity => rarity;
        public string Name => itemName;
        public string DecoratedName => $"<b><color={Rarity.GetColor()}>{Name}</color></b>";
    }
}