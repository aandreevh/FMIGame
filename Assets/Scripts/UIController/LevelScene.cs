using System;
using UnityEditor;
using UnityEngine;

namespace UIController
{
    [CreateAssetMenu(fileName = "LevelScene", menuName = "ScriptableObjects/LevelScene", order = 1)]
    public class LevelScene : ScriptableObject
    {
        public SceneAsset scene;
        public int level;
        public SceneAsset Scene
        {
            get => scene;
        }

        public int Level
        {
            get => level;
        }
        
    }
}