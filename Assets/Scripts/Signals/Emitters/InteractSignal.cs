using System;
using System.Collections;
using UnityEngine;

namespace Signals.Emitters
{
    public class InteractSignal : Signal
    {
        public event Action<GameObject> OnFailed;
        public void Interact(GameObject obj)
        {
            if (MeetsRequirements(obj)) ChangeSignal(!Signaled);
            else OnFailed?.Invoke(obj);
        }
        

        protected virtual bool MeetsRequirements(GameObject _)
        {
            return true;
        }



    }
}