namespace VisitorPattern.Graphics
{
    using System;

    class Dot : Shape
    {
        protected int x, y;

        public override void Draw()
        {
            Console.WriteLine("Drawing a dot.");
        }

        public override void Accept(IVisitor visitor)
        {
            // Compiler knows for sure that `this` is a `Dot`.
            // Which means that the `Visit(Dot dot)` can be safely called.
            visitor.Visit(this);
        }
    }
}
