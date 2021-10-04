namespace VisitorPattern.MathExpressions.Extension
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public static class ExpressionPrinter
    {
        // While it’s not possible to statically enforce the presence of every single necessary
        // type check, it is possible to generate exceptions if the appropriate implementation
        // is missing. To do this, simply make a dictionary that maps the supported types to
        // lambda functions that process those types.

        // Whether or not you use extension methods or just ordinary static or instance methods
        // on a Printer is intirely irrelevant for the purposes of SRP. Both an ordinary class
        // and an extension-method class serve to isolate printing functionality from the data
        // structures themselves, the only difference being whether or not you consider printing
        // part of Expression’s API.

        private static Dictionary<Type, Action<Expression, StringBuilder>> actions = new()
        { 
            [typeof(DoubleExpression)] = (e, sb) =>
            {
                var de = (DoubleExpression)e;
                sb.Append(de.Value);
            },

            [typeof(AdditionExpression)] = (e, sb) =>
            {
                var ae = (AdditionExpression)e;
                sb.Append("(");
                Print(ae.Left, sb);
                sb.Append(" + ");
                Print(ae.Right, sb);
                sb.Append(")");
            }
        };

        // Use the C# extension methods mechanic to add Print() as a method of any Expression.
        public static void Print(this Expression e, StringBuilder sb)
        {
            actions[e.GetType()](e, sb);
        }
    }
}
