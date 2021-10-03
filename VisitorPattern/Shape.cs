using System;

namespace VisitorPattern
{
    class Shape : IGraphic
    {
        protected int id;

        public virtual void Draw()
        {
            Console.WriteLine("Drawing a shape.");
        }

        public virtual void Accept(IVisitor visitor)
        {
            // Compiler knows for sure that `this` is a `Shape`.
            // Which means that the `Visit(Shape shape)` can be safely called.
            visitor.Visit(this);
        }
    }
}
