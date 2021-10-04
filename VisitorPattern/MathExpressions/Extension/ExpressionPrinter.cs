namespace VisitorPattern.MathExpressions.Extension
{
    using System;
    using System.Text;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;

    public static class ExpressionPrinter
    {
        // Extension method classes are static, and can have both static fields and
        // constructors, so we can map out all the inheritors and attempt to find
        // the methods that handle them.

        private static Dictionary<Type, MethodInfo> methods = new Dictionary<Type, MethodInfo>();

        static ExpressionPrinter()
        {
            var assembly = typeof(Expression).Assembly;

            var classes = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Expression)));

            var printMethods = typeof(ExpressionPrinter).GetMethods();

            foreach (var c in classes)
            {
                var pm = printMethods
                    .FirstOrDefault(
                        m => m.Name.Equals(nameof(Print)) &&
                        m.GetParameters()?[0]?.ParameterType == c);

                methods.Add(c, pm);
            }
        }

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
            methods[e.GetType()].Invoke(null, new object[] { e, sb });
        }
    }
}
