using Signals.Receivers.Unary;

namespace World.Objects
{
    public class Door : UnaryReceiver
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