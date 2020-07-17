using Signals.Receivers.Binary;

namespace Signals.Transmitters.Binary
{
    public class BinaryTransmitterReceiver : BinaryReceiver
    {
        private BinaryTransmitter Transmitter { get; set; }

        protected void Awake()
        {
            Transmitter = GetComponent<BinaryTransmitter>();
        }

        protected override void OnSignalAcquired(SignalType type)
        {
            Transmitter.UpdateTransmitter(LeftSignal, RightSignal, type);
        }

        protected override void OnSignalLost(SignalType type)
        {
            Transmitter.UpdateTransmitter(LeftSignal, RightSignal, type);
        }
    }
}