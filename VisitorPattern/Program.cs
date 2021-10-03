using System;

using VisitorPattern.Graphics;
using VisitorPattern.MathExpressions;

namespace VisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Drawing feature\n");
            Draw(new CompoundGraphic());

            Console.WriteLine("\nExporting feature\n");
            Export(new Exporter(), new CompoundGraphic()); // Does not work.
            Export(new ExporterVisitor(), new CompoundGraphic());
        }

        static void Draw(IGraphic graphic)
        {
            // Uses late (link object and its implementation after compilation at runtime)
            // or dynamic (every new object might be linked to a different implementation)
            // binding for overridden methods.
            graphic.Draw();
        }

        static void Export(Exporter exporter, IGraphic graphic) 
        {
            // Uses early (at compile time) or static (can't be altered at runtime)
            // binding for overloaden methods. Does not work.
            exporter.Export(graphic);
        }

        static void Export(ExporterVisitor exporter, IGraphic graphic)
        {
            // Uses double dispatch by allowing the dynamic binding alongside
            // with overloaded methods.
            // The `Accept` method is overriden, not overloaded. Compiler binds it
            // dynamically. Therefore the `Accept` will be executed on a class that
            // corresponds to an object defined at runtime.
            graphic.Accept(exporter);
        }
    }
}

