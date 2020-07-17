using UnityEngine;

namespace Signals.Receivers.Binary
{
    public class BinaryReceiver : MonoBehaviour
    {
        public enum SignalType
        {
            Left,
            Right
        }

        [Header("Receiver")] [SerializeField] private Signal left;

        [SerializeField] private Signal right;

        public Signal LeftSignal => left;
        public Signal RightSignal => right;

        protected virtual void OnSignalAcquired(SignalType type)
        {
        }

        protected virtual void OnSignalLost(SignalType type)
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
            if (LeftSignal) LeftSignal.OnSignalChangedEvent += SignalChangedLeftHook;
            if (RightSignal) RightSignal.OnSignalChangedEvent += SignalChangedRightHook;
        }

        private void RemoveHooks()
        {
            if (LeftSignal) LeftSignal.OnSignalChangedEvent -= SignalChangedLeftHook;
            if (RightSignal) RightSignal.OnSignalChangedEvent -= SignalChangedRightHook;
        }

        private void SignalChangedLeftHook()
        {
            if (!LeftSignal) return;
            if (LeftSignal.Signaled)
                OnSignalAcquired(SignalType.Left);
            else OnSignalLost(SignalType.Left);
        }

        private void SignalChangedRightHook()
        {
            if (!RightSignal) return;
            if (RightSignal.Signaled)
                OnSignalAcquired(SignalType.Right);
            else OnSignalLost(SignalType.Right);
        }

        protected virtual void OnDrawGizmos()
        {
            const float pointRadius = 0.2f;
            var position = transform.position;
            if (LeftSignal)
            {
                Gizmos.color = LeftSignal.Signaled ? Color.green : Color.red;
                var signalPosition = LeftSignal.transform.position;
                Gizmos.DrawLine(signalPosition, position);
                Gizmos.DrawSphere(signalPosition, pointRadius);
            }

            if (RightSignal)
            {
                var signalPosition = RightSignal.transform.position;
                Gizmos.color = RightSignal.Signaled ? Color.green : Color.red;
                Gizmos.DrawLine(signalPosition, position);
                Gizmos.DrawSphere(signalPosition, pointRadius);
            }
        }
    }
}