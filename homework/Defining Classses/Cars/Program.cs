using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //int numOfCars = int.Parse(Console.ReadLine());
        //string action = string.Empty;
        //Dictionary<string, Car> cars = new Dictionary<string, Car>();

        //for (int car = 0; car < numOfCars; car++)
        //{
        //    string[] carData = Console.ReadLine().Split();
        //    cars.Add(carData[0], new Car(carData[0], float.Parse(carData[1]), float.Parse(carData[2])));
        //}

        //while ((action = Console.ReadLine()) != "End")
        //{
        //    string[] currAction = action.Split();

        //    var currCar = cars[currAction[1]];
        //    float distanceToTravel = float.Parse(currAction[2]);
        //    float fuelToSubs = distanceToTravel * currCar.distancePerKm;
        //    bool canPass = currCar.fuelAmmount - fuelToSubs < 0 ? false : true;

        //    if (canPass)
        //    {
        //        currCar.fuelAmmount -= fuelToSubs;
        //        currCar.distanceTraveled += float.Parse(currAction[2]);
        //    }
        //    else
        //        Console.WriteLine("Insufficient fuel for the drive");
        //}

        //foreach (var car in cars)
        //{
        //    var currCar = car.Value;
        //    Console.WriteLine("{0} {1:0.00} {2}", currCar.model, currCar.fuelAmmount, currCar.distanceTraveled);
        //}

        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Queue<string> input = new Queue<string>(Console.ReadLine().Split());

            string model = input.Dequeue();
            int engineSpeed = Convert.ToInt32(input.Dequeue());
            int enginePower = Convert.ToInt32(input.Dequeue());
            int cargoWeight = Convert.ToInt32(input.Dequeue());
            string cargoType = input.Dequeue();
            Cargo cargo = new Cargo(cargoType, cargoWeight);
            Car car = new Car(model, enginePower, engineSpeed, cargo);

            int tireAge = -1;
            double tirePressure = -1;

            /* 0 - store tire pressure
             * 1 - store tire age 
             * 2 - add tire to car 
             */
            short counter = 0;

            while (true)
            {
                switch (counter)
                {
                    case 0:
                        tirePressure = Double.Parse(input.Dequeue());
                        break;
                    case 1:
                        tireAge = Convert.ToInt32(input.Dequeue());
                        break;
                    case 2:
                        car.AddTire(new Tire(tireAge, tirePressure));
                        break;
                }
                counter++;
                counter %= 3;

                if (input.Count == 0)
                {
                    car.AddTire(new Tire(tireAge, tirePressure));
                    break;
                }
            }
        }

        string command = Console.ReadLine().ToLower();

        Car.Print(Car.Calc(command));
    }

    private class Car
    {
        private string _model;
        private int _engineSpeed;
        private int _enginePower;
        private Cargo _cargo;
        private List<Tire> _tires = new List<Tire>();
        private static readonly List<Car> Cars = new List<Car>();

        public Car(string model, int enginePower, int engineSpeed, Cargo cargo)
        {
            this._model = model;
            this._enginePower = enginePower;
            this._engineSpeed = engineSpeed;
            this._cargo = cargo;

        }

        private Car(int enginePower, int engineSpeed, Cargo cargo, string model, List<Tire> tires)
        {
            this._model = model;
            this._enginePower = enginePower;
            this._engineSpeed = engineSpeed;
            this._cargo = cargo;
            this._tires = tires;
        }

        public void AddTire(Tire tire)
        {
            if (_tires.Count < 4)
                _tires.Add(tire);

            if (_tires.Count == 4)
                Cars.Add(new Car(_enginePower, _engineSpeed, _cargo, _model, _tires));
        }

        public static void Print(IEnumerable<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car._model);
            }
        }

        public static IEnumerable<Car> Calc(string command)
        {
            IEnumerable<Car> filteredCars = new Car[4];
            switch (command)
            {
                case "fragile":
                    filteredCars = Cars
                        .Where(c => c._cargo.CargoType == command)
                        .Where(c => c._tires.Count(t => t.Pressure < 1) > 0);
                    break;
                case "flamable":
                    filteredCars = Cars
                        .Where(c => c._enginePower > 250)
                        .Where(c => c._cargo.CargoType == command);
                    break;
            }

            return filteredCars;
        }
    }

    private class Tire
    {
        private int _age;
        private double _pressure;

        public Tire(int age, double pressure)
        {
            _age = age;
            _pressure = pressure;
        }

        public double Pressure
        {
            get { return _pressure; }
            set { _pressure = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
    }

    private class Cargo
    {
        private string _cargoType;
        private int _cargoWeight;

        public Cargo(string cargoType, int cargoWeight)
        {
            _cargoType = cargoType;
            _cargoWeight = cargoWeight;
        }

        public int CargoWeight
        {
            get { return _cargoWeight; }
            set { _cargoWeight = value; }
        }

        public string CargoType
        {
            get { return _cargoType; }
            set { _cargoType = value; }
        }
    }
}
