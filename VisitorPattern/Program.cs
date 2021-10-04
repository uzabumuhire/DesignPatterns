namespace VisitorPattern
{
    using System;
    using System.Text;

    using Intrusive = MathExpressions.Intrusive;
    using Reflexive = MathExpressions.Reflexive;

    class Program
    {
        static void Main(string[] args)
        {
            PrintInfo("GRAPHICS");

            PrintInfo("Drawing feature");
            Draw(new Graphics.CompoundGraphic());

            PrintInfo("Exporting feature");
            Export(new Graphics.Exporter(), new Graphics.CompoundGraphic()); // Does not work.
            Export(new Graphics.ExporterVisitor(), new Graphics.CompoundGraphic());

            PrintInfo("MATH EXPRESSIONS");

            PrintInfo("Intrusive implementation of visitor pattern");
            PrintExpressionIntrusive();

            PrintInfo("Reflexive implementation of visitor pattern");
            PrintExpressionReflexive();
        }

        static void Draw(Graphics.IGraphic graphic)
        {
            // Uses late (link object and its implementation after compilation at runtime)
            // or dynamic (every new object might be linked to a different implementation)
            // binding for overridden methods.
            graphic.Draw();
        }

        static void Export(Graphics.Exporter exporter, Graphics.IGraphic graphic) 
        {
            // Uses early (at compile time) or static (can't be altered at runtime)
            // binding for overloaden methods. Does not work.
            exporter.Export(graphic);
        }

        static void Export(Graphics.ExporterVisitor exporter, Graphics.IGraphic graphic)
        {
            // Uses double dispatch by allowing the dynamic binding alongside
            // with overloaded methods.
            // The `Accept` method is overriden, not overloaded. Compiler binds it
            // dynamically. Therefore the `Accept` will be executed on a class that
            // corresponds to an object defined at runtime.
            graphic.Accept(exporter);
        }

        static void PrintExpressionIntrusive()
        {
            var ae = new Intrusive.AdditionExpression(
                left: new Intrusive.DoubleExpression(1),
                right: new Intrusive.AdditionExpression(
                    left: new Intrusive.DoubleExpression(2),
                    right: new Intrusive.DoubleExpression(3)));
            
            var sb = new StringBuilder();

            ae.Print(sb);

            Console.WriteLine(sb);
        }

        static void PrintExpressionReflexive()
        {
            var ae = new Reflexive.AdditionExpression(
                left: new Reflexive.DoubleExpression(1),
                right: new Reflexive.AdditionExpression(
                    left: new Reflexive.DoubleExpression(2),
                    right: new Reflexive.DoubleExpression(3)));

            var sb = new StringBuilder();

            Reflexive.ExpressionPrinter.Print(ae, sb);

            Console.WriteLine(sb);
        }

        static void PrintInfo(string info)
        {
            Console.WriteLine($"\n{info}\n");
        }
    }
}

