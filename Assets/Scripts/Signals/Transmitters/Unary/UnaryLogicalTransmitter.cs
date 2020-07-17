using UnityEngine;

namespace Signals.Transmitters.Unary
{
    public class UnaryLogicalTransmitter : UnaryTransmitter
    {

        [SerializeField] private UnaryOperator op;
        
        public UnaryOperator Op => op;
        protected override void TransformSignal(Signal signal)
        {
            ChangeSignal(Operate(signal));
        }

        private bool Operate(Signal signal)
        {
            var leftVal = Op.CheckNecessary() && signal.Signaled;
            return Op.Evaluate(leftVal);
        }
    }
}