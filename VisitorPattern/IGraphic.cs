namespace VisitorPattern
{
    interface IGraphic
    {
        void Draw();
        void Accept(IVisitor visitor);
    }
}
