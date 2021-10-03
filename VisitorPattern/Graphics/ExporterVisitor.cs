using System;

namespace VisitorPattern.Graphics
{
    // Visitor lets you add “external” operations to a whole class hierarchy
    // without changing the existing code of these classes.
    class ExporterVisitor : IVisitor
    {
        public void Export(Shape shape)
        {
            Console.WriteLine("Exporting a shape.");
        }

        public void Visit(Shape shape)
        {
            Export(shape);
        }

        public void Export(Dot dot)
        {
            Console.WriteLine("Exporting a dot.");
        }

        public void Visit(Dot dot)
        {
            Export(dot);
        }

        public void Export(Circle circle)
        {
            Console.WriteLine("Exporting a circle.");
        }

        public void Visit(Circle circle)
        {
            Export(circle);
        }

        public void Export(Rectangle rectangle)
        {
            Console.WriteLine("Exporting a rectangle.");
        }

        public void Visit(Rectangle rectangle)
        {
            Export(rectangle);
        }

        public void Export(CompoundGraphic compoundGraphic)
        {
            Console.WriteLine("Exporting a compound graphic : ");
            foreach (var graphic in compoundGraphic.Graphics)
                Console.WriteLine(" - Exporting a " + graphic.GetType().Name.ToLower());
        } 

        public void Visit(CompoundGraphic compoundGraphic)
        {
            Export(compoundGraphic);
        }
    }
}
