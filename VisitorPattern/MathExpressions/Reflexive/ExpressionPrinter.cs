namespace VisitorPattern.MathExpressions.Reflexive
{
    using System.Text;

    public static class ExpressionPrinter
    {
        public static void Print(DoubleExpression de, StringBuilder sb)
        {
            sb.Append(de.Value);
        }

        public static void Print(AdditionExpression ae, StringBuilder sb)
        {
            sb.Append("(");
            Print(ae.Left, sb); // Does not compile : cannot convert Expression into DoubleExpression
            sb.Append(" + "); 
            Print(ae.Right, sb); // Does not compile : cannot convert Expression into DoubleExpression
            sb.Append(")");
        }
    }
}
