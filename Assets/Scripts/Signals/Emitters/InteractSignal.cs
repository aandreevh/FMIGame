using System.Collections;
using UnityEngine;

namespace Signals.Emitters
{
    public class InteractSignal : Signal
    {
        [SerializeField] private bool hasInteractTimeout;
        [SerializeField] private float interactTimeout;
        public float InteractTimeout => interactTimeout;
        [SerializeField,HideInInspector]
        private float timeout = 0;

        public float Timeout
        {
            get => timeout;
            private set=> timeout = value;
        }

        public bool HasInteractTimeout => hasInteractTimeout;

        public void Interact(GameObject obj)
        {
            if(MeetsRequirements(obj)) UpdateSignal();
        }

        protected virtual bool MeetsRequirements(GameObject _) {return true;}

        private void UpdateSignal()
        {
            if (HasInteractTimeout)
            {
                if (!Signaled)
                {
                    ChangeSignal(true);
                    StartCoroutine(nameof(SignalCoroutine));  
                }
            }
            else
            {
                ChangeSignal(!Signaled);
            }
       
        }

        private IEnumerator SignalCoroutine()
        {
            Timeout = InteractTimeout;
            
            while (Signaled)
            {
                Timeout -= Time.deltaTime;
                if (Timeout <= 0)
                {
                    ChangeSignal(false);
                    yield break;
                }

                yield return null;
            }

            yield return null;
        }
    }
}