using Global.Level;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class ButtonGenerator : MonoBehaviour
    {
        public GameObject buttonPrefab;

        public LevelManager manager;
        public GameObject panelToAttachButtonsTo;

        private void OnEnable()
        {
            if (manager.IsLoaded) CreateButtons();
            else manager.OnLoaded += CreateButtons;
        }

        public void CreateButtons()
        {
            for (var i = 0; i < manager.LevelScenes.Count; i++)
                CreateButton(manager.LevelScenes[i].Scene.name,
                    manager.LevelScenes[i].Level,
                    manager.LevelStates[i].IsAvailable);
        }

        public void CreateButton(string sceneName, int level, bool isAvailable)
        {
            var button = Instantiate(buttonPrefab);

            button.transform.SetParent(panelToAttachButtonsTo.transform);
            button.GetComponent<Button>().onClick.AddListener(() => { OnClick(sceneName); });
            button.transform.GetChild(0).GetComponent<Text>().text = "Level " + level;
            button.GetComponent<Button>().interactable = isAvailable;
        }

        private void OnClick(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}