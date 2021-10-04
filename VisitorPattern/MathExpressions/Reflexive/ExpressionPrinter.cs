namespace VisitorPattern.MathExpressions.Reflexive
{
    using System.Text;

    public static class ExpressionPrinter
    {
        public static void Print(Expression e, StringBuilder sb)
        {
            // Remove the overloads and check the type at runtime
            if (e is DoubleExpression de)
                sb.Append(de.Value);
            else if (e is AdditionExpression ae)
            {
                sb.Append("(");
                Print(ae.Left, sb);
                sb.Append(" + ");
                Print(ae.Right, sb);
                sb.Append(")");
            }
        }
    }
}
