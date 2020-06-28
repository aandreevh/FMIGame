using System.Linq;
using Tracker;
using UnityEngine;

namespace Signals.Emitters
{
    [RequireComponent(typeof(CollisionTracker))]
    public class PressureSignal : Signal
    {
        [SerializeField]
        private float massThreshold;
        private CollisionTracker Tracker { get; set; }
        public float MassThreshold => massThreshold;
        protected virtual void Awake()
        {
            Tracker = GetComponent<CollisionTracker>();
        }
        protected virtual void OnConfigChanged()
        {
            UpdateActive();   
        }

        private void UpdateActive()
        {
            ChangeSignal(GetTotalMass() > MassThreshold);
        }
        private float GetTotalMass()
        {
            return Tracker.Colliders.Select(e => e.attachedRigidbody.mass).Sum();
        }

        private void OnEnable()
        {
            AddHooks();
        }

        private void OnDisable()
        {
            RemoveHooks();
        }
        
        private void AddHooks()
        {
            Tracker.OnColliderEnter += CollisionChangeHook;
            Tracker.OnColliderExit += CollisionChangeHook;
        }
        private void RemoveHooks()
        {
            Tracker.OnColliderEnter -= CollisionChangeHook;
            Tracker.OnColliderExit -= CollisionChangeHook;
        }
        private void CollisionChangeHook(Collider2D _)
        {
            UpdateActive();
        }

     
      
    }
}