using System.Collections;
using UnityEngine;

namespace Signals.Emitters
{
    public class TimedSignal : Signal
    {

        [SerializeField] private float timeActivated;
        [SerializeField] private float timeDeactivated;
        [SerializeField] private float timeout;
        public float TimeActivated => timeActivated;
        public float TimeDeactivated => timeDeactivated;
        public float Timeout
        {
            get => timeout;
            private set => timeout = value;
        }
        
        protected override void Start()
        {
            base.Start();
            StartCoroutine(nameof(TimeUpdate));
        }
        private IEnumerator TimeUpdate()
        {
            bool lastState = Signaled;
            SetTimeout();
            
            while (true)
            {
                if (Signaled != lastState)
                {
                    SetTimeout();
                    lastState = Signaled;
                }
                UpdateTimeout();
                yield return null;
            }
        }

        private void UpdateTimeout()
        {
            Timeout -= Time.deltaTime;
            if (Timeout <= 0)
            {
                ChangeSignal(!Signaled);
                SetTimeout();
            }
        }
        
        private void SetTimeout()
        {
            Timeout = Signaled ? TimeActivated : TimeDeactivated;
        }
    }
}