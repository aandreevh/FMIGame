namespace Signals.Transmitters.Unary
{
    /**
     * Same logic as BinaryOperator, but much simpler
     */
    public enum UnaryOperator
    {
        F = 0b00,
        Ident = 0b10,
        Not = 0b01,
        T = 0b11
    }

    public static class UnaryOperatorMethods
    {
        public static bool CheckNecessary(this UnaryOperator op)
        {
            return op == UnaryOperator.Ident || op == UnaryOperator.Not;
        }

        public static bool Evaluate(this UnaryOperator op, bool value)
        {
           return bitSign((int) op, value ? 0b10 : 0b01);
        }
        private static bool bitSign(int val, int mask)
        {
            return (val & mask) > 0;
        }
    }
}