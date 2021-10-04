namespace VisitorPattern.Graphics
{
    using System;

    class Circle : Dot
    { 
        protected int radius;

        public override void Draw()
        {
            Console.WriteLine("Drawing a circle.");
        }

        public override void Accept(IVisitor visitor)
        {
            // Compiler knows for sure that `this` is a `Circle`.
            // Which means that the `visit(Circle circle)` can be safely called.
            visitor.Visit(this);
        }
    }
}
