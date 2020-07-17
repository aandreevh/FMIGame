namespace Signals.Transmitters.Binary
{
    /**
     * For more information check: https://en.wikipedia.org/wiki/Truth_table
     * The transformations are based on logical connection. The idea is
     * that if a value for left/right operand is unecessary it's not taken
     * into account. This avoids null references of non connected signal if not needed.
     *
     * I know it's not best practices, but connections are too cased
     */
    public enum BinaryOperator
    {
        F = 0b0000,
        Nor = 0b0001,
        Xq = 0b0010,
        Np = 0b0011,
        L = 0b0100,
        Nq = 0b0101,
        Xor = 0b0110,
        NAnd = 0b0111,
        And = 0b1000,
        XNor = 0b1001,
        Q = 0b1010,
        IfThen = 0b1011,
        P = 0b1100,
        ThenIf = 0b1101,
        Or = 0b1110,
        T = 0b1111
    }
    
    public static class BinaryOperatorMethods
    {
        public static bool CheckNecessaryLeft(this BinaryOperator op)
        {
            return BitSign((int) op, 0b1000) != BitSign((int) op, 0b0010)
                   || BitSign((int) op, 0b0100) != BitSign((int) op, 0b0001);
        }
        
        public static bool CheckNecessaryRight(this BinaryOperator op)
        {
             return BitSign((int) op, 0b1000) != BitSign((int) op, 0b0100)
                          || BitSign((int) op, 0b0010) != BitSign((int) op, 0b0001);
        }

        public static bool Evaluate(this BinaryOperator op,bool left, bool right)
        {
            var leftVal = op.CheckNecessaryLeft() && left;
            var rightVal = op.CheckNecessaryRight() && right;
            
            var val = 0b1;
            if (leftVal) val = val << 2;
            if (rightVal) val = val << 1;
            return ((int) op & val) != 0;
        }
       
        private static bool BitSign(int val, int mask)
        {
            return (val & mask) > 0;
        }
        
    }
}