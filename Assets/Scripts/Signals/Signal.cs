using System;
using UnityEngine;

namespace Signals
{
    public class Signal : MonoBehaviour
    {
        [Header("Signal")] [SerializeField] private bool signaled;

        public bool Signaled => signaled;
        public event Action OnSignalChangedEvent;

        protected virtual void Start()
        {
            ChangeSignal(Signaled, true);
        }

        protected bool ChangeSignal(bool isSignaled, bool forcedToNotify = false)
        {
            if (Signaled == isSignaled && !forcedToNotify) return false;
            signaled = isSignaled;
            
            OnSignalChangedEvent?.Invoke();
            
            return true;
        }
    }
}