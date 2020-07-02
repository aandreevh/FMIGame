using Tracker;
using UnityEngine;

namespace UIController
{
    public class EndLevelObject : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.tag == "Player")
            {
                LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
                levelManager.LevelPassed();
                EndGameUI endGameUI = GetComponent<EndGameUI>();
                endGameUI.ToggleEndGameMenu();
            }
        }
    }
}