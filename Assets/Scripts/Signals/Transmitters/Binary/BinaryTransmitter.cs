using Signals.Receivers.Binary;
using UnityEngine;

namespace Signals.Transmitters.Binary
{
    [RequireComponent(typeof(BinaryTransmitterReceiver))]
    public class BinaryTransmitter : Signal
    {
        protected virtual void TransformSignal(Signal left, Signal right, BinaryReceiver.SignalType type) {}

        internal void UpdateTransmitter(Signal left, Signal right, BinaryReceiver.SignalType type)
        {
            TransformSignal(left, right, type);
        }
    }
}