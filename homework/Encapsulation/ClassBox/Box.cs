using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Box
{
    private double _length;
    private double _width;
    private double _height;

    public double Length
    {
        get { return _length; }
        private set
        {
            if (value <= 0)
                throw new ArgumentException("Length cannot be zero or negative.");
            _length = value;
        }
    }

    public double Width
    {
        get { return _width; }
        private set
        {
            if (value <= 0)
                throw new ArgumentException("Width cannot be zero or negative.");
            _width = value;
        }
    }

    public double Height
    {
        get { return _height; }
        private set
        {
            if (value <= 0)
                throw new ArgumentException("Height cannot be zero or negative.");
            _height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Volume()
    {
        return this.Length * this.Width * this.Height;
    }

    public double LateralSurfaceArea()
    {
        return 2 * (this.Length * this.Height + this.Width * this.Height);
    }

    public double SurfaceArea()
    {
        return 2 * (this.Length * this.Width + this.Length * this.Height + this.Width * this.Height);
    }

    public override string ToString()
    {
        return
            $"Surface Area - {this.SurfaceArea():F2}\n" +
            $"Lateral Surface Area - {this.LateralSurfaceArea():F2}\n" +
            $"Volume - {this.Volume():F2}";
    }
}