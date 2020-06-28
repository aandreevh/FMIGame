using System.Collections;
using Signals.Receivers.Unary;
using Tracker;
using UnityEngine;
using World.Actors;
using World.Navigation;

namespace World.Objects
{
    [RequireComponent(
        typeof(CollisionTracker),
        typeof(Agent))]
    public class Platform : UnaryReceiver
    {
        private CollisionTracker Tracker { get; set; }
        private Agent Agent { get; set; }
        protected void Awake()
        {
            Tracker = GetComponent<CollisionTracker>();
            Agent = GetComponent<Agent>();
        }

        protected override void OnSignalAcquired()
        {
            StartCoroutine(nameof(UpdatePlatform));
        }

        protected override void OnSignalLost()
        {
            StopCoroutine(nameof(UpdatePlatform));
        }

        private IEnumerator UpdatePlatform()
        {
            while (true)
            {
                UpdateAllActorsMovement(Agent.UpdateAgent());
                yield return null;
            }
        }

        private void UpdateAllActorsMovement(Vector2 movement)
        {
            foreach (var actor in Tracker.GetAsComponents<Actor>())
            {
                actor.Move(movement);
            }
        }
    }
}
