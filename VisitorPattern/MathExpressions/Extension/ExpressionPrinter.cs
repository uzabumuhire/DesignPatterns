namespace VisitorPattern.MathExpressions.Extension
{
    using System.Text;

    public static class ExpressionPrinter
    {
        public static void Print(this DoubleExpression de, StringBuilder sb)
        {
            sb.Append(de.Value);
        }

        public static void Print(this AdditionExpression ae, StringBuilder sb)
        {
            sb.Append("(");
            Print(ae.Left, sb);
            sb.Append(" + ");
            Print(ae.Right, sb);
            sb.Append(")");
        }
        public static void Print(this Expression e, StringBuilder sb)
        {
            // This has the same problem as the Reflexive approach, because by
            // implementing an extension method on the root element of the hierarchy
            // and perform type checks. There’s no verification to ensure that
            // every inheritor of Expression is covered by the switch statement.
            switch (e)
            {
                case DoubleExpression de:
                    de.Print(sb);
                    break;
                case AdditionExpression ae:
                    ae.Print(sb);
                    break;
            }
        }
    }
}
