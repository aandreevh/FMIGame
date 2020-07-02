using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UIController
{
    public class LevelManager : MonoBehaviour
    {
        static LevelManager _instance;
        public static LevelManager instance {
            get {
                if (_instance == null) {
                    GameObject manager= new GameObject("[GameManager]");
                    _instance = manager.AddComponent<LevelManager>();
                    DontDestroyOnLoad(manager);
                }
                return _instance;
            }
        }

        public List<LevelScene> LevelScenes = new List<LevelScene>();

        [SerializeField]
        public ButtonGenerator buttonGenerator;
    
        private List<LevelState> LevelStates = new List<LevelState>();
        private void Start()
        {
            if(_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad (this);
            }
            else
            {
                if(this != _instance)
                    Destroy(this.gameObject);
            }
        
            SortLevelScenes();
            SaveManager.CreateSaveGame(LevelScenes);
            LevelStates = SaveManager.LoadGame().LevelStates;

            for (int i = 0; i < LevelScenes.Count; i++)
            {
                buttonGenerator.CreateButton(LevelScenes[i].Scene.name, LevelScenes[i].Level, LevelStates[i].IsAvailable);
            }
        }

        public void LevelPassed()
        {
            for (int i = 0; i < LevelStates.Count; i++)
            {
                if (i + 1 < LevelStates.Count && LevelStates[i + 1].IsAvailable == false)
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
