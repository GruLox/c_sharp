using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Interfaces.Shapes;

public class Rectangle(float a, float b) : Shape
{
    public float A { get; set; } = a;
    public float B { get; set; } = b;

    public override float Area() => A * B;

    public override float Perimeter() => 2 * (A + B);
}
