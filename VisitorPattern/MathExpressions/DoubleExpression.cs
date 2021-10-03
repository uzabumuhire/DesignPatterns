namespace VisitorPattern.MathExpressions
{
    class DoubleExpression : Expression
    {
        private double value;

        public DoubleExpression(double value)
        {
            this.value = value;
        }
    }
}
