using UnityEngine;

namespace Signals.Receivers.Unary
{
    public class UnaryReceiver : MonoBehaviour
    {
        [Header("Receiver")] [SerializeField] private Signal signal;

        public Signal Signal => signal;

        protected virtual void OnSignalAcquired()
        {
        }

        protected virtual void OnSignalLost()
        {
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
            if (!Signal) return;
            Signal.OnSignalChangedEvent += SignalChangedHook;
        }

        private void RemoveHooks()
        {
            if (!Signal) return;
            Signal.OnSignalChangedEvent -= SignalChangedHook;
        }

        private void SignalChangedHook()
        {
            if (!Signal) return;
            if (Signal.Signaled) OnSignalAcquired();
            else OnSignalLost();
        }

        protected virtual void OnDrawGizmos()
        {
            if (!Signal) return;
            
            const float pointRadius = 0.2f;
            
            Gizmos.color = Signal.Signaled ? Color.green : Color.red;
            
            var signalPosition = Signal.transform.position;
            Gizmos.DrawLine(signalPosition, transform.position);
            Gizmos.DrawSphere(signalPosition, pointRadius);
        }
    }
}