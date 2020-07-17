using Signals.Receivers.Binary;
using UnityEngine;

namespace Signals.Transmitters.Binary
{
    public class BinaryLogicalTransmitter : BinaryTransmitter
    {
        [SerializeField] private BinaryOperator op;

        public BinaryOperator Op => op;

        protected override void TransformSignal(Signal left, Signal right, BinaryReceiver.SignalType type)
        {
            ChangeSignal(Operate(left, right));
        }

        private bool Operate(Signal left, Signal right)
        {
            var leftVal = Op.CheckNecessaryLeft() && left.Signaled;
            var rightVal = Op.CheckNecessaryRight() && right.Signaled;

            return Op.Evaluate(leftVal, rightVal);
        }


    }
}