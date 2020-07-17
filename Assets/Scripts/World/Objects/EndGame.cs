using Global.Level;
using Signals.Receivers.Unary;
using Tracker;
using UnityEngine;

namespace World.Objects
{
    [RequireComponent(typeof(CollisionTracker))]
    public class EndGame : UnaryReceiver
    {
        [SerializeField] private GameObject endMenu;
        [SerializeField] private LevelManager manager;
        [SerializeField] private bool winning;

        private CollisionTracker Tracker { get; set; }
        private LevelManager Manager => manager;
        public bool Winning => winning;
        private GameObject EndMenu => endMenu;

        protected override void OnSignalAcquired()
        {
            if (Tracker.Colliders.Count > 0) StopGame();
        }

        protected override void OnSignalLost()
        {
        }

        private void Awake()
        {
            Tracker = GetComponent<CollisionTracker>();
            Tracker.OnColliderEnter += StopGame;
        }

        private void StopGame(Collider2D _ = null)
        {
            if (Signal.Signaled)
            {
                Time.timeScale = 0;
                if (Winning) Manager.LevelPassed();
                EndMenu.SetActive(true);
            }
        }
    }
}