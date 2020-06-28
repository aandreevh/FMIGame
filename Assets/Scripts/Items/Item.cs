using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Item")]
    public class Item : ScriptableObject
    {
        [SerializeField]
        private Sprite image;

        [SerializeField] private string itemName;

        public Sprite Image => image;
        public string Name => itemName;
    }
}
