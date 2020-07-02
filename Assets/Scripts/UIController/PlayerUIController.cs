using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIController
{
    public class PlayerUIController : MonoBehaviour
    {
        public GameObject pauseUI;
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

        public void TogglePause()
        {
            pauseUI.SetActive(!pauseUI.activeSelf);
        
            if (pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        public void ToggleRetry()
        {
            TogglePause();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    
        public void ToggleGoToMenu()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
