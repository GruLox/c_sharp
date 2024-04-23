public abstract class Shape : IShape
{
    public abstract float Area();
    public abstract float Perimeter();
    public override string ToString() => $"Area: {Area()}\nPerimeter: {Perimeter()}";
}
