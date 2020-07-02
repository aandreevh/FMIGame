using System;
using Global.Level;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    
    public class ButtonGenerator : MonoBehaviour
    {
        public GameObject buttonPrefab;
        public GameObject panelToAttachButtonsTo;

        public LevelManager manager;

        private void OnEnable()
        {
            if (manager.IsLoaded) CreateButtons();
            else manager.OnLoaded += CreateButtons;
        }

        public void CreateButtons()
        {
            for (int i = 0; i < manager.LevelScenes.Count; i++)
            {
                CreateButton(manager.LevelScenes[i].Scene.name, 
                    manager.LevelScenes[i].Level,
                    manager.LevelStates[i].IsAvailable);
            }
        }

        public void CreateButton(string sceneName, int level, bool isAvailable)
        {
            GameObject button = Instantiate(buttonPrefab) as GameObject;
            
            button.transform.SetParent(panelToAttachButtonsTo.transform);
            button.GetComponent<Button>().onClick.AddListener(() => { OnClick(sceneName); });
            button.transform.GetChild(0).GetComponent<Text>().text = "Level " + level.ToString();
            button.GetComponent<Button>().interactable = isAvailable;
        }
        void OnClick(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}