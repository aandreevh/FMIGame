using Signals.Receivers.Unary;
using Tracker;
using UnityEngine;

namespace World.Navigation
{
    [RequireComponent(typeof(CollisionTracker))]
    public class Teleport : UnaryReceiver
    {
        [SerializeField] private Point location;
        [SerializeField] private bool teleportEnabled;

        public bool TeleportEnabled
        {
            get => teleportEnabled;
            set => teleportEnabled = value;
        }

        public Vector3 TeleportLocation => location.Position;
        public CollisionTracker TeleportTracker { get; set; }

        private void Start()
        {
            TeleportTracker = GetComponent<CollisionTracker>();
            TeleportTracker.OnColliderEnter += TeleportCollider;
        }

        private void TeleportCollider(Collider2D other)
        {
            if (TeleportEnabled && location)
            {
                var entity = other.transform;
                entity.position = TeleportLocation;
            }
        }

        protected override void OnSignalAcquired()
        {
            TeleportEnabled = true;
        }

        protected override void OnSignalLost()
        {
            TeleportEnabled = false;
        }
    }
}