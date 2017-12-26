using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 2; i++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            for (int j = 0; j < n; j++)
            {
                Queue<string> input = new Queue<string>(Console.ReadLine().Split());
                if (i == 0) // Engines input
                {
                    string model = input.Dequeue();
                    int power = Convert.ToInt32(input.Dequeue());
                    int displacement = -1;
                    string efficiency = "n/a";

                    if (input.Count > 0)
                    {
                        if (input.Peek().Any(char.IsDigit))
                        {
                            displacement = Convert.ToInt32(input.Dequeue());
                        }

                        if (input.Count > 0)
                        {
                            if (input.Peek().Any(char.IsLetter))
                            {
                                efficiency = input.Dequeue();
                            }
                        }
                    }

                    new Engine(model, power, displacement, efficiency);
                }
                else // Cars input
                {
                    string model = input.Dequeue();
                    string engineModel = input.Dequeue();
                    Engine engine = Engine.FindEngine(engineModel);
                    string color = "n/a";
                    int weight = -1;

                    if (input.Count > 0)
                    {
                        if (input.Peek().Any(char.IsDigit))
                        {
                            weight = Convert.ToInt32(input.Dequeue());
                        }

                        if (input.Count > 0)
                        {
                            if (input.Peek().Any(char.IsLetter))
                            {
                                color = input.Dequeue();
                            }
                        }
                    }
                    new Car(model, weight, color, engine);

                }

            }
        }

        Car.PrintCars();
    }

    private class Car
    {
        private string _model;
        private int _weight = -1;
        private string _color = "n/a";
        private Engine _engine;
        private static readonly List<Car> Cars = new List<Car>();

        public Car(string model, int weight, string color, Engine engine)
        {
            _model = model;
            _weight = weight;
            _color = color;
            _engine = engine;

            Cars.Add(new Car(_model, _engine, _weight, _color));

        }

        public Car(string model, int weight, Engine engine)
        {
            _model = model;
            _weight = weight;
            _engine = engine;

            Cars.Add(new Car(_model, _engine, _weight, _color));

        }

        public Car(string model, string color, Engine engine)
        {
            _model = model;
            _color = color;
            _engine = engine;

            Cars.Add(new Car(_model, _engine, _weight, _color));

        }

        public Car(string model, Engine engine)
        {
            _model = model;
            _engine = engine;

            Cars.Add(new Car(_model, _engine, _weight, _color));
        }

        private Car(string model, Engine engine, int weight, string color)
        {
            _model = model;
            _engine = engine;
            _weight = weight;
            _color = color;
        }

        public static void PrintCars()
        {
            Cars.ForEach(c => Console.WriteLine(c.ToString()));
        }

        public override string ToString()
        {
            dynamic weight = _weight == -1 ? (dynamic)"n/a" : _weight;
            return $"{_model}:\n  {_engine.ToString()}\n  Weight: {weight}\n  Color: {_color}";
        }

    }

    private class Engine
    {
        private string _model;
        private int _power;
        private int _displacement = -1;
        private string _efficiency = "n/a";
        private static readonly List<Engine> Engines = new List<Engine>();

        public Engine(string model, int power, int displacement, string efficiency)
        {
            _model = model;
            _power = power;
            _displacement = displacement;
            _efficiency = efficiency;

            Engines.Add(new Engine(_power, _model, _displacement, _efficiency));
        }

        public Engine(string model, int power, string efficiency)
        {
            _model = model;
            _power = power;
            _efficiency = efficiency;

            Engines.Add(new Engine(_power, _model, _displacement, _efficiency));

        }

        public Engine(string model, int power, int displacement)
        {
            _model = model;
            _power = power;
            _displacement = displacement;

            Engines.Add(new Engine(_power, _model, _displacement, _efficiency));

        }

        public Engine(string model, int power)
        {
            _model = model;
            _power = power;

            Engines.Add(new Engine(_power, _model, _displacement, _efficiency));

        }

        public Engine()
        {
            _model = "n/a";
            _power = -1;
        }

        private Engine(int power, string model, int displacement, string efficiency)
        {
            _power = power;
            _model = model;
            _displacement = displacement;
            _efficiency = efficiency;
        }

        public static Engine FindEngine(string model)
        {
            return Engines.First(e => e._model == model);
        }

        public override string ToString()
        {
            dynamic displacement = _displacement == -1 ? (dynamic)"n/a" : _displacement;
            return $"{_model}:\n    Power: {_power}\n" +
                   $"    Displacement: {displacement}\n    Efficiency: {_efficiency}";
        }
    }
}
