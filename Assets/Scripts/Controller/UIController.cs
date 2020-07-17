using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controller
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private SceneAsset menuScene;
        [SerializeField] private GameObject pauseUI;

        public SceneAsset MenuScene => menuScene;
        public GameObject PauseUI => pauseUI;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) TogglePause();
        }

        public void TogglePause()
        {
            pauseUI.SetActive(!PauseUI.activeSelf);

            if (PauseUI.activeSelf)
                Time.timeScale = 0f;
            else
                Time.timeScale = 1f;
        }

        public void ToggleRetry()
        {
            TogglePause();
            ReloadScene();
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ToggleGoToMenu()
        {
            SceneManager.LoadScene(MenuScene.name);
        }
    }
}