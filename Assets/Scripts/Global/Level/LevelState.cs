using System;
using UnityEngine;

namespace Global.Level
{
    [Serializable]
    public class LevelState
    {
        [SerializeField] private bool isAvailable;
        [SerializeField] private string levelName;

        public LevelState(string levelName, bool isAvailable)
        {
            LevelName = levelName;
            IsAvailable = isAvailable;
        }

        public string LevelName
        {
            get => levelName;
            set => levelName = value;
        }

        public bool IsAvailable
        {
            get => isAvailable;
            set => isAvailable = value;
        }
    }
}