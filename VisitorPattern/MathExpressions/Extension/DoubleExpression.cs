namespace VisitorPattern.MathExpressions.Extension
{
    public class DoubleExpression : Expression
    {
        private double value;

        public double Value => value;

        public DoubleExpression(double value)
        {
            this.value = value;
        }
    }
}
