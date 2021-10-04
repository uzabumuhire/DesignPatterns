

namespace VisitorPattern.MathExpressions.Intrusive
{
    using System.Text;

    public class AdditionExpression : Expression
    {
        private Expression left, right;

        public AdditionExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public override void Print(StringBuilder sb)
        {
            // Use polymorphism and recursion to print the expression.
            sb.Append("(");
            left.Print(sb);
            sb.Append(" + ");
            right.Print(sb);
            sb.Append(")");
        }
    }
}
