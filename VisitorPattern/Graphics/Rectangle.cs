namespace VisitorPattern.Graphics
{
    using System;

    class Rectangle : Shape
    {
        protected int width, height;

        public override void Draw()
        {
            Console.WriteLine("Drawing a rectangle.");
        }

        public override void Accept(IVisitor visitor)
        {
            // Compiler knows for sure that `this` is a `Rectangle`.
            // Which means that the `Visit(Rectangle rectangle)` can be safely called.
            visitor.Visit(this);
        }
    }
}
