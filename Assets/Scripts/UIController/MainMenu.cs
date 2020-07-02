using UnityEngine;

namespace UIController
{
    public class MainMenu : MonoBehaviour
    {
        public void ToggleExit()
        {
#if UNITY_EDITOR
        
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
    }
}
