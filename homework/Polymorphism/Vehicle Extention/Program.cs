using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelPerKm, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelPerKm = fuelPerKm;
        this.TankCapacity = tankCapacity;
    }

    public override void Refuel(double fuel)
    {
        double fuelSpace = TankCapacity - FuelQuantity;
        if (fuelSpace < fuel)
            throw new ArgumentException("Cannot fit fuel in tank");

        this.FuelQuantity += fuel;
    }

    public override void TravelDistance(double distance)
    {

    }

    public void TravelDistance(double distance, bool isEmpty)
    {
        double requiredFuel;

        if (isEmpty)
            requiredFuel = distance * this.FuelPerKm;
        else
            requiredFuel = distance * (this.FuelPerKm + 1.4);

        if (requiredFuel <= this.FuelQuantity)
        {
            Console.WriteLine($"Bus travelled {distance} km");
            this.FuelQuantity -= requiredFuel;
        }
        else
            Console.WriteLine($"Bus needs refueling");
    }

    public override string ToString()
    {
        return $"Bus: {this.FuelQuantity:F2}";
    }

}
public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelPerKm, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelPerKm = fuelPerKm + 1.6;
        this.TankCapacity = tankCapacity;
    }

    public override void Refuel(double fuel)
    {
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
    public Car(double fuelQuantity, double fuelPerKm, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelPerKm = fuelPerKm + 0.9;
        this.TankCapacity = tankCapacity;
    }

    public override void Refuel(double fuel)
    {
        double fuelSpace = TankCapacity - FuelQuantity;
        if (fuelSpace < fuel)
            throw new ArgumentException("Cannot fit fuel in tank");

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
    private double tankCapacity;

    public double TankCapacity
    {
        get
        {
            return this.tankCapacity;
        }

        protected set
        {
            this.tankCapacity = value;
        }
    }

    public double FuelQuantity
    {
        get
        {
            return this.fuelQuantity;
        }

        protected set
        {
            if (value < 0)
                throw new ArgumentException("Fuel must be a positive number");

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
        Car myCar = new Car(vehicleData[0], vehicleData[1], vehicleData[2]);
        vehicleData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
        Truck myTruck = new Truck(vehicleData[0], vehicleData[1], vehicleData[2]);
        vehicleData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
        Bus myBus = new Bus(vehicleData[0], vehicleData[1], vehicleData[2]);

        int numOfInputs = int.Parse(Console.ReadLine());

        for (int input = 0; input < numOfInputs; input++)
        {
            string[] command = Console.ReadLine().Split();

            try
            {
                if (command[1].Equals("Car"))
                {
                    if (command[0].Equals("Drive"))
                        myCar.TravelDistance(double.Parse(command[2]));
                    else
                        myCar.Refuel(double.Parse(command[2]));
                }
                else if (command[1].Equals("Truck"))
                {
                    if (command[0].Equals("Drive"))
                        myTruck.TravelDistance(double.Parse(command[2]));
                    else
                        myTruck.Refuel(double.Parse(command[2]));
                }
                else
                {
                    if (command[0].Equals("DriveEmpty"))
                        myBus.TravelDistance(double.Parse(command[2]), true);
                    else if (command[0].Equals("Drive"))
                        myBus.TravelDistance(double.Parse(command[2]), false);
                    else
                        myBus.Refuel(double.Parse(command[2]));
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        Console.WriteLine(myCar);
        Console.WriteLine(myTruck);
        Console.WriteLine(myBus);
    }
}
