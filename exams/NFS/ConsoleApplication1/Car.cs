using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public abstract class Car
{
    public Car(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
    {

    }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int YearOfProduction { get; set; }
    public int HorsePower { get; set; }
    public int Acceleration { get; set; }
    public int Suspension { get; set; }
    public int Durability { get; set; }

    public override string ToString()
    {
        return $"{this.Brand} {this.Model} {this.YearOfProduction}\n{this.HorsePower} HP, 100 m/h in {this.Acceleration} s\n{this.Suspension} Suspension force, {this.Durability} Durability";
    }
}