using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    public class PerformanceCar : Car
    {
    public PerformanceCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability) : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
        this.AddOns = new List<string>();
    }

    public ICollection<string> AddOns { get; set; }


        public override string ToString()
        {
            var addons = $"{string.Join(", ", this.AddOns)}";
            if (string.IsNullOrEmpty(addons))
            {
                addons = "None";
            }
            return base.ToString() + $"\nAdd-ons: {addons}";
        }
    }
