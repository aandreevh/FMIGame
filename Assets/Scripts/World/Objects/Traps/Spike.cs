using Signals;
using Signals.Receivers;
using Signals.Receivers.Unary;

namespace World.Objects.Traps
{
    public class Spike : UnaryReceiver
    {
        protected override void OnSignalAcquired()
        {
            base.OnSignalAcquired();
        }

        protected override void OnSignalLost()
        {
            base.OnSignalLost();
        }
    }
}