using UnityEngine;

namespace Signals.Emitters
{
    public class TrueSignal : Signal
    {
        [SerializeField] private bool signaled;

        protected override void Start()
        {
            ChangeSignal(signaled, true);
        }
    }
}