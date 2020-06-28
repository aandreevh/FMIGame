using UnityEngine;

namespace Signals.Transmitters.Unary
{
    public class UnaryLogicalTransmitter : UnaryTransmitter
    {
        [SerializeField] private Operator op;
        public Operator Op => op;
        protected override void TransformSignal(Signal signal)
        {
            ChangeSignal(Operate(signal));
        }

        private bool Operate(Signal signal)
        {
            bool leftVal = CheckNecessary() && signal.Signaled;
            return bitSign((int)op,leftVal ? 0b10 : 0b01);
        }

        //Check if signal is needed(if not dont not get, helps if signal is null)
        private bool CheckNecessary()
        {
            return Op == Operator.Ident || Op == Operator.Not;
        }
        
        private bool bitSign(int val, int mask)
        {
            return (val & mask) > 0;
        }

        public enum Operator
        {
            F = 0b00,
            Ident = 0b10,
            Not = 0b01,
            T = 0b11
        }
    }
}