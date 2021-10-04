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
            // This approach has significant performance costs. There are ways to offset
            // these costs, such as using Delegate.CreateDelegate() to avoid storing those
            // MethodInfo objects and instead having ready-to-call delegates when the need
            // arises.

            // There is a possibility of generating code that creates those calls at runtime.
            // Of course, this comes with its own set of problems: you’ll be generating code
            // either on the basis of reflection  or by inspecting actual written code using
            // a parser framework provided by Roslyn, ReSharper, Rider ...

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
