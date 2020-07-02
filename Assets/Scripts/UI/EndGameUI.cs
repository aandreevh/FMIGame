using UnityEngine;

namespace UI
{
    public class EndGameUI : MonoBehaviour
    {
        public GameObject endGameUI;

        public void ToggleEndGameMenu()
        {
            endGameUI.SetActive(true);
        }
    }
}