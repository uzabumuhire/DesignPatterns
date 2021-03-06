namespace VisitorPattern.MathExpressions.Reflexive
{
    using System.Text;

    public static class ExpressionPrinter
    {
        public static void Print(Expression e, StringBuilder sb)
        {
            // Remove the overloads and check the type at runtime

            // While this approach confirms to SRP and OCP, it has two downsides :
            // 1. There are no compiler checks that you have, in fact, implemented
            //    printing for every single element in the hierarchy or for newly 
            //    added types. Remember you might not have access to source code
            //    that contains the hierarchy.
            // 2. The is operator has a performance cost.

            // The is operator tests whether a reference conversion would succeed;
            // in other words, whether an object derives from a specified class or
            // implements an interface.

            // You can introduce a variable that represents the converted type and 
            // the introduced variable  remains in scope outside the is expression.

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
