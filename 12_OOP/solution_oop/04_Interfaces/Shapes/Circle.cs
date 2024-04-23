namespace _04_Interfaces.Shapes;

public class Circle(float radius)
{
    public float Radius { get; set; } = radius;

    public float Area() => MathF.PI * Radius * Radius;

    public float Perimeter() => 2 * MathF.PI * Radius;
}
