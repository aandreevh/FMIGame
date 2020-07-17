using System;
using System.Collections.Generic;
using Global.Level;
using UnityEngine;

namespace Global
{
    [Serializable]
    public class SaveData
    {
        [SerializeField] private List<LevelState> levelStates = new List<LevelState>();

        public SaveData(List<LevelScene> levelScenes)
        {
            LevelStates = new List<LevelState>(new LevelState[levelScenes.Count])
            {
                [0] = new LevelState(levelScenes[0].Scene.name, true)
            };

            for (var i = 1; i < levelScenes.Count; i++)
                LevelStates[i] = new LevelState(levelScenes[0].Scene.name, false);
        }

        public SaveData(List<LevelState> levelStates)
        {
            LevelStates = levelStates;
        }

        public List<LevelState> LevelStates
        {
            get => levelStates;
            set => levelStates = value;
        }
    }
}