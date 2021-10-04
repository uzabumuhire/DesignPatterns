namespace VisitorPattern.Graphics
{
    using System;
    class CompoundGraphic : IGraphic
    {
        internal IGraphic[] Graphics = new IGraphic[]
        {
            new Shape(),
            new Dot(),
            new Circle(),
            new Rectangle()

        };

        public void Draw()
        {
            Console.WriteLine("Drawing a compound graphic : ");
            foreach (var graphic in Graphics)
                graphic.Draw();
        }

        public virtual void Accept(IVisitor visitor)
        {
            // Compiler knows for sure that `this` is a `CompoundGraphic`.
            // Which means that the `Visit(CompoundGraphic compoundGraphic)` can be safely called.
            visitor.Visit(this);
        }
    }
}
