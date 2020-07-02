using System;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace Global.Level
{
    public class LevelManager : MonoBehaviour
    {
        
        [SerializeField] private List<LevelScene> levelScenes;
       public List<LevelScene> LevelScenes
       {
           get => levelScenes;
           private set => levelScenes = value;
       }
        public List<LevelState> LevelStates { get; private set; } = new List<LevelState>();
        
        public bool IsLoaded { get;  private set; }
        public event Action OnLoaded;
        
        private void Start()
        {
            
            Time.timeScale = 1;
            SortLevelScenes();
            SaveManager.CreateSaveGame(LevelScenes);
            LevelStates = SaveManager.LoadGame().LevelStates;
            IsLoaded = true;
            OnLoaded?.Invoke();
        }

        public void LevelPassed()
        {
            for (int i = 0; i < LevelStates.Count-1; i++)
            {
                if (LevelStates[i + 1].IsAvailable == false)
                {
                    LevelStates[i + 1].IsAvailable = true;
                    break;
                }
            }
            SaveManager.SaveGame(LevelStates);
        }

        private void SortLevelScenes()
        {
            LevelScenes = LevelScenes.OrderBy(levelScene => levelScene.Level).ToList();
        }
    }
}
