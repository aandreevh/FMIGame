using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace Tracker
{
    [RequireComponent(typeof(Collider2D),
        typeof(Rigidbody2D))]
    public class CollisionTracker : MonoBehaviour 
    {

        public enum AccessPolicyType
        {
            Access,Deny
        }

        [SerializeField] private bool fromCollisions=true;
        [SerializeField] private bool fromTriggers = true;
        
        [Header("Layers")]
        [SerializeField] private List<LayerMask> layerAccessList;
        [SerializeField] private AccessPolicyType layerPolicy = AccessPolicyType.Deny;
        
        [Header("Tags")]
        [SerializeField] private List<string> tagAccesList;
        [SerializeField] private AccessPolicyType tagPolicy = AccessPolicyType.Deny;
        
        public bool FromCollisions => fromCollisions;
        public bool FromTriggers => fromTriggers;
        
        public List<LayerMask> LayerAccessList => layerAccessList;
        public AccessPolicyType LayerPolicy => layerPolicy;
        
        public List<string> TagAccessList => tagAccesList;
        public AccessPolicyType TagPolicy => tagPolicy;

        public HashSet<Collider2D> Colliders { get; } = new HashSet<Collider2D>();
        
        public event Action<Collider2D> OnColliderEnter;
        public event Action<Collider2D> OnColliderExit;
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (FromTriggers && QualifyAccess(other))
            {
                Colliders.Add(other);
                OnColliderEnter?.Invoke(other);
            }
          
        }

        protected void OnTriggerExit2D(Collider2D other)
        {
            if (Colliders.Contains(other))
            {
                Colliders.Remove(other);
                OnColliderExit?.Invoke(other);
            }
        
        }

        protected void OnCollisionEnter2D(Collision2D collision)
        {
            var other = collision.collider;
            if (FromCollisions && QualifyAccess(other))
            {
                Colliders.Add(other);
                OnColliderEnter?.Invoke(other);
            }
           
        }

        protected void OnCollisionExit2D(Collision2D collision)
        { 
            var other = collision.collider;

            if (Colliders.Contains(other))
            {
                Colliders.Remove(other);
                OnColliderExit?.Invoke(other);
            }
        }

        private bool QualifyAccess(Collider2D collider)
        {
            return QualifyLayers(collider) && QualifyTags(collider);
        }

        private bool QualifyLayers(Collider2D collider)
        {
            bool hasAccess = LayerPolicy == AccessPolicyType.Access;
            foreach (var mask in LayerAccessList)
            {
                if (mask == (mask | (1 << collider.gameObject.layer))) return hasAccess;
            }

            return !hasAccess;
        }

        private bool QualifyTags(Collider2D collider)
        {
            bool hasAccess = TagPolicy == AccessPolicyType.Access;
            foreach (var tg in TagAccessList)
            {
                if (collider.gameObject.CompareTag(tg)) return hasAccess;
            }
            return !hasAccess;
        }

        public IEnumerable<T> GetAsComponents<T>() where T : Component
        {
            return Colliders.Select(e => e.GetComponent<T>())
                .Where(e => e);
        }

    }
}
