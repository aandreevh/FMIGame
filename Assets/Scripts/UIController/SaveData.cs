using System;
using System.Collections.Generic;
using UnityEngine;

namespace UIController
{
    [Serializable]
    public class SaveData
    {
        public List<LevelState> LevelStates = new List<LevelState>();

        /** TODO: ITEMS COLLECTED**/
        
        public SaveData(List<LevelScene> levelScenes)
        {
            LevelStates = new List<LevelState>(new LevelState[levelScenes.Count]);

            LevelStates[0] = new LevelState(levelScenes[0].Scene.name,true);
            
            for (int i = 1; i < levelScenes.Count; i++)
            {
                LevelStates[i] = new LevelState(levelScenes[0].Scene.name,false);
            }
        }
        
        public SaveData(List<LevelState> levelStates)
        {
            LevelStates = levelStates;
        }
    }
}