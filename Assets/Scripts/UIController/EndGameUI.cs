using UnityEngine;

namespace UIController
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