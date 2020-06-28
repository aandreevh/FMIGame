using System;
using Signals.Receivers.Binary;
using UnityEngine;

namespace Signals.Transmitters.Binary
{
    public class BinaryLogicalTransmitter : BinaryTransmitter
    {

        [SerializeField]
        private Operator op;
        public Operator Op => op;
        
        protected override void TransformSignal(Signal left, Signal right, BinaryReceiver.SignalType type)
        {
            ChangeSignal(Operate(left, right));
        }

        private bool Operate(Signal left, Signal right)
        { 
            bool leftVal = CheckNecessary(BinaryReceiver.SignalType.Left) && left.Signaled;
            bool rightVal = CheckNecessary( BinaryReceiver.SignalType.Right) && right.Signaled;
           
            int val = 0b1;
            if (leftVal) val = val << 2;
            if (rightVal) val = val << 1;
            return ((int) Op & val )!=0;
        }

        //Check if signal is needed(if not might not get, helps if signal is null)
        private bool CheckNecessary(BinaryReceiver.SignalType signal)
        {
            if (signal == BinaryReceiver.SignalType.Left)
            {
                return bitSign((int) Op, 0b1000) != bitSign((int) Op, 0b0010)
                       || bitSign((int) Op, 0b0100) != bitSign((int) Op, 0b0001);
            }
            return bitSign((int) Op, 0b1000) != bitSign((int) Op, 0b0100)
                   || bitSign((int) Op, 0b0010) != bitSign((int) Op, 0b0001);
     
            
        }

        private bool bitSign(int val, int mask)
        {
            return (val & mask) > 0;
        }
        
        /**
         * Reference: https://en.wikipedia.org/wiki/Bitwise_operation
         */
        public enum Operator :int
        {
            F =0b0000,
            Nor = 0b0001,
            Xq = 0b0010,
            Np = 0b0011,
            L = 0b0100,
            Nq = 0b0101,
            Xor = 0b0110,
            Nand = 0b0111,
            And = 0b1000,
            XNor = 0b1001,
            Q = 0b1010,
            IfThen = 0b1011,
            P = 0b1100,
            ThenIf = 0b1101,
            Or = 0b1110,
            T = 0b1111
        }
    }
}