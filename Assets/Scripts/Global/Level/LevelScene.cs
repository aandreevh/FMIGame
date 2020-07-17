using UnityEditor;
using UnityEngine;

namespace Global.Level
{
    [CreateAssetMenu(fileName = "LevelScene", menuName = "ScriptableObjects/LevelScene", order = 1)]
    public class LevelScene : ScriptableObject
    {
        [SerializeField] private int level;
        [SerializeField] private SceneAsset scene;

        public SceneAsset Scene => scene;
        public int Level => level;
    }
}