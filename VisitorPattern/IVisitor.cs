namespace VisitorPattern
{
    interface IVisitor
    {
        void Visit(Shape shape);
        void Visit(Dot dot);
        void Visit(Circle circle);
        void Visit(Rectangle rectangle);
        void Visit(CompoundGraphic compoundGraphic);
    }
}
