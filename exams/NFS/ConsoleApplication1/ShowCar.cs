using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    public class ShowCar : Car
    {
    public ShowCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability) : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
    }

    public int Stars { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\n{this.Stars} *";
        }
    }