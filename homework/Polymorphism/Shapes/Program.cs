using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public double Radius
    {
        get
        {
            return this.radius;
        }
        private set
        {
            this.radius = value;
        }
    }

    public override double CalculateArea()
    {
        return Math.PI * this.radius * this.radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * this.radius;
    }

    public override string Draw()
    {
        return base.Draw() + "Circle";
    }
}
class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width
    {
        get
        {
            return this.width;
        }
        private set
        {
            this.width = value;
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }
        private set
        {
            this.height = value;
        }
    }

    public override double CalculateArea()
    {
        return this.width * this.height;
    }

    public override double CalculatePerimeter()
    {
        return 2 * this.width + 2 * this.height;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}
abstract class Shape
{
    abstract public double CalculatePerimeter();

    abstract public double CalculateArea();

    virtual public string Draw()
    {
        return "Drawing ";
    }
}
class Program
{
    static void Main(string[] args)
    {
        var shapes = new List<Shape>();
        shapes.Add(new Rectangle(3, 4));
        shapes.Add(new Circle(120.34));

        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape.Draw()}, area: {shape.CalculateArea():f2} perimeter: {shape.CalculatePerimeter():f2}");
        }
    }
}
