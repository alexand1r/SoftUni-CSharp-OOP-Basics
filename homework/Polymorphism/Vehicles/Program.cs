using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelPerKm)
    {
        base.FuelQuantity = fuelQuantity;
        base.FuelPerKm = fuelPerKm + 1.6;
    }

    public override void Refuel(double fuel)
    {
        if (fuel < 0)
            throw new ArgumentException();

        this.FuelQuantity += fuel * 0.95;
    }

    public override void TravelDistance(double distance)
    {
        double requiredFuel = distance * this.FuelPerKm;
        if (requiredFuel <= this.FuelQuantity)
        {
            Console.WriteLine($"Truck travelled {distance} km");
            this.FuelQuantity -= requiredFuel;
        }
        else
            Console.WriteLine($"Truck needs refueling");
    }

    public override string ToString()
    {
        return $"Truck: {this.FuelQuantity:F2}";
    }

}
public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelPerKm)
    {
        base.FuelQuantity = fuelQuantity;
        base.FuelPerKm = fuelPerKm + 0.9;
    }

    public override void Refuel(double fuel)
    {
        if (fuel < 0)
            throw new ArgumentException();

        this.FuelQuantity += fuel;
    }

    public override void TravelDistance(double distance)
    {
        double requiredFuel = distance * this.FuelPerKm;
        if (requiredFuel <= this.FuelQuantity)
        {
            Console.WriteLine($"Car travelled {distance} km");
            this.FuelQuantity -= requiredFuel;
        }
        else
            Console.WriteLine($"Car needs refueling");
    }

    public override string ToString()
    {
        return $"Car: {this.FuelQuantity:F2}";
    }

}
public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelPerKm;

    public double FuelQuantity
    {
        get
        {
            return this.fuelQuantity;
        }

        protected set
        {
            if (value < 0)
                throw new ArgumentException();

            this.fuelQuantity = value;
        }
    }

    public double FuelPerKm
    {
        get
        {
            return fuelPerKm;
        }

        protected set
        {
            if (value < 0)
                throw new ArgumentException();

            this.fuelPerKm = value;
        }
    }

    public abstract void Refuel(double fuel);
    public abstract void TravelDistance(double distance);

}
class Program
{
    static void Main(string[] args)
    {
        double[] vehicleData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
        Vehicle myCar = new Car(vehicleData[0], vehicleData[1]);
        vehicleData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
        Vehicle myTruck = new Truck(vehicleData[0], vehicleData[1]);

        int numOfInputs = int.Parse(Console.ReadLine());

        for (int input = 0; input < numOfInputs; input++)
        {
            string[] command = Console.ReadLine().Split();

            if (command[1].Equals("Car"))
            {
                if (command[0].Equals("Drive"))
                    myCar.TravelDistance(double.Parse(command[2]));
                else
                    myCar.Refuel(double.Parse(command[2]));
            }
            else
            {
                if (command[0].Equals("Drive"))
                    myTruck.TravelDistance(double.Parse(command[2]));
                else
                    myTruck.Refuel(double.Parse(command[2]));
            }
        }

        Console.WriteLine(myCar);
        Console.WriteLine(myTruck);
    }
}

//Car 15 0.3
//Truck 100 0.9
//4
//Drive Car 9
//Drive Car 30
//Refuel Car 50
//Drive Truck 10
