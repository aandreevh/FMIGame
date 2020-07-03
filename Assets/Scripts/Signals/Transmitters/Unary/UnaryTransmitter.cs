using UnityEngine;

namespace Signals.Transmitters.Unary
{
    
    [RequireComponent(typeof(UnaryTransmitterReceiver))]
    public class UnaryTransmitter : Signal
    {

        protected virtual void TransformSignal(Signal signal)
        {
            ChangeSignal(signal.Signaled);
        }

        internal void UpdateTransmitter(Signal signal)
        {
            TransformSignal(signal);
        }
    }
}