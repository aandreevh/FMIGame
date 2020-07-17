using System.Collections;
using UnityEngine;

namespace Signals.Transmitters.Unary
{
    public class LockerTransmitter : UnaryTransmitter
    {
        [SerializeField] private float timeout;
        [SerializeField] private bool unlockable;
        [SerializeField] private float unlockTimeout;
      
        public bool IsUnlockable => unlockable;
        public float UnlockTimeout => unlockTimeout;
        public float Timeout
        {
            get => timeout;
            private set => timeout = value;
        }

        protected override void Start()
        {
            StartUnlocking();
        }

        protected override void TransformSignal(Signal signal)
        {
            if (Signaled & !signal.Signaled)
            {
                StartUnlocking();
            }
            else if (signal.Signaled)
            {
                ChangeSignal(true);
                StopUnlocking();
            }
        }

        private void StopUnlocking()
        {
            StopCoroutine(nameof(UnlockCoroutine));
        }

        private void StartUnlocking()
        {
            if (IsUnlockable && Signaled) StartCoroutine(nameof(UnlockCoroutine));
        }

        private IEnumerator UnlockCoroutine()
        {
            Timeout = UnlockTimeout;

            while (true)
            {
                Timeout -= Time.deltaTime;
                if (Timeout < 0)
                {
                    ChangeSignal(false);
                    yield break;
                }

                yield return null;
            }
        }
    }
}