using UnityEditor;
using UnityEngine;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public void ToggleExit()
        {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}