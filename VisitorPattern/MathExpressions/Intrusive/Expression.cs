namespace VisitorPattern.MathExpressions.Intrusive
{
    using System.Text;

    public abstract class Expression
    {
        // This breaks the Open Closed Principle (OCP) and is based on the 
        // assumption that you have access this source code, which is not
        // always the case. Imagine you’ve got 10 inheritors in the hierarchy
        // and you need to add some new Eval() operation. That’s 10 modifications
        // that need to be done in 10 different classes.

        // This also violates the Single Responsibility Principle (SRP) because
        // printing is a special concern. Rather than stating that every expression
        // should print itself, why not introduce an ExpessionPrinter that knows how
        // to print expressions? And, later on, you can introduce an ExpressionEvaluator
        // that knows how to perform the actual calculations.All without affecting
        // the Expression hierarchy in any way.
 
        public abstract void Print(StringBuilder sb);
    }
}
