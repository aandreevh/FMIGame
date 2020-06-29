using UnityEngine;

namespace Items
{
    public enum ItemRarity
    {
        Common,
        Rare,
        Artefact
        
    }

    public static class ItemRarityMethods
    {
        public static string GetColor(this ItemRarity rarity)
        {
            switch (rarity)
            {
                case ItemRarity.Common:
                    return "green";
                case ItemRarity.Rare:
                    return "yellow";
                case ItemRarity.Artefact:
                    return "red";
                default:
                    return null;
            }
        }
    }
}