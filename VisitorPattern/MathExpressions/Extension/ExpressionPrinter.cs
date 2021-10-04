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
