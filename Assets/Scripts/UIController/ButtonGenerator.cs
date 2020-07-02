using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIController
{
    
    public class ButtonGenerator : MonoBehaviour
    {
        public GameObject buttonPrefab;
        public GameObject panelToAttachButtonsTo;

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