namespace VisitorPattern.MathExpressions.Intrusive
{
    using System.Text;

    public abstract class Expression
    {
        // This breaks the Open Closed Principle (OCP) and is based on the 
        // assumption that you have access this source code, which is not
        // always the case.
        public abstract void Print(StringBuilder sb);
    }
}
