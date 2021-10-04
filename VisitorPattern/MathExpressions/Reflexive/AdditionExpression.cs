namespace VisitorPattern.MathExpressions.Reflexive
{
    public class AdditionExpression : Expression
    {
        private Expression left, right;
 
        public Expression Left => left;
        public Expression Right => right;

        public AdditionExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }
    }
}
