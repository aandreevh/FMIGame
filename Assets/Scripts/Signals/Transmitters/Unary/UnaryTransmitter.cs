using UnityEngine;

namespace Signals.Transmitters.Unary
{
    
    [RequireComponent(typeof(UnaryTransmitterReceiver))]
    public class UnaryTransmitter : Signal
    {

        protected virtual void TransformSignal(Signal signal){}

        internal void UpdateTransmitter(Signal signal)
        {
            TransformSignal(signal);
        }
    }
}