using System;
using UnityEngine;

namespace Signals
{
    public class Signal : MonoBehaviour
    { 
        [Header("Signal")]
        [SerializeField] private bool signaled;
        public bool Signaled => signaled;

        public event Action OnSignalChangedEvent;
        

        protected virtual void Start()
        {
            ChangeSignal(Signaled, true); // force signal emmit at the start
        }

        protected bool ChangeSignal(bool isSignaled,bool forced = false)
        {
            if (Signaled == isSignaled & !forced) return false;
            signaled = isSignaled;
            OnSignalChangedEvent?.Invoke();
            return true;
        }
        
    }
}