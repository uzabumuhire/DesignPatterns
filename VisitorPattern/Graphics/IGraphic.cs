namespace VisitorPattern.Graphics
{
    interface IGraphic
    {
        void Draw();
        void Accept(IVisitor visitor);
    }
}
