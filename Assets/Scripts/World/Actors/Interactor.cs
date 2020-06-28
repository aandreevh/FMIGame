using System;
using System.Collections;
using Signals.Emitters;
using UnityEngine;

namespace World.Actors
{
    public class Interactor : MonoBehaviour
    {
        [Header("Interaction")] [SerializeField]
        private float radius;

        [SerializeField]private float interactTimeout = 1f;
        public float InteractionTime => interactTimeout;
        
        [SerializeField]private float timeout;

        public float Timeout
        {
            get => timeout;
            private set => timeout = value;
        }

        [SerializeField] private Vector3 offset;

        public float Radius => radius;
        public Vector3 Center => transform.position + offset;

        private void Start()
        {
            if (Timeout > 0) StartCoroutine(nameof(InteractionCooldown));
        }

        public void Interact(Vector3 direction)
        {
            if (Timeout <= 0)
            {
                ApplyInteraction(direction);
                Timeout= InteractionTime;
                StartCoroutine(nameof(InteractionCooldown));
            }
        }

        private IEnumerator InteractionCooldown()
        {
            while (true)
            {
                Timeout -= Time.deltaTime;
                if(Timeout <=0) yield break;
                yield return null; 
            }
        }

        private void ApplyInteraction(Vector3 direction)
        {
            
            Debug.DrawRay(Center, Radius * direction);
            RaycastHit2D[] hits = Physics2D.RaycastAll(Center, direction, Radius);

            foreach (var hit in hits)
            {
                var interactable = hit.collider.GetComponent<InteractSignal>();
                if (interactable)
                {
                    interactable.Interact(gameObject);
                }
            }
        }
    }
}