using System;

namespace VisitorPattern.Graphics
{
    class Exporter
    {
        public void Export(IGraphic graphic)
        {
            Console.WriteLine("Exporting a graphic.");
        }

        public void Export(Shape shape)
        {
            Console.WriteLine("Exporting a shape.");
        }

        public void Export(Dot dot)
        {
            Console.WriteLine("Exporting a dot.");
        }

        public void Export(Circle circle)
        {
            Console.WriteLine("Exporting a circle.");
        }

        public void Export(Rectangle rectangle)
        {
            Console.WriteLine("Exporting a rectangle.");
        }

        public void Export(CompoundGraphic compoundGraphic)
        {
            Console.WriteLine("Exporting a compound graphic : ");
            foreach (var graphic in compoundGraphic.Graphics)
                Console.WriteLine(" - Exporting a " + graphic.GetType().Name.ToLower());
        }
    }
}
