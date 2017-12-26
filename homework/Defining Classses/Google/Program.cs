using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static void Main()
    {
        List<Person> peoples = new List<Person>();

        while (true)
        {
            Queue<string> input = new Queue<string>(Console.ReadLine().Split());

            if (input.Peek().ToLower() == "end")
                break;

            string name = input.Dequeue();

            Person person = peoples.FirstOrDefault(p => p.Name == name) ?? new Person(name);
            string infoType = input.Dequeue();

            switch (infoType.ToLower())
            {
                case "company":
                    string companyName = input.Dequeue();
                    string department = input.Dequeue();
                    decimal salary = Decimal.Parse(input.Dequeue());
                    Company company = new Company(companyName, department, salary);

                    person.UpdatePerson(company);
                    break;
                case "car":
                    string carModel = input.Dequeue();
                    int carSpeed = Convert.ToInt32(input.Dequeue());
                    Car car = new Car(carModel, carSpeed);

                    person.UpdatePerson(car);
                    break;

                case "pokemon":
                    string pokemonName = input.Dequeue();
                    string pokemonType = input.Dequeue();
                    Pokemon pokemon = new Pokemon(pokemonName, pokemonType);

                    person.UpdatePerson(pokemon);
                    break;

                case "parents":
                    string parentName = input.Dequeue();
                    string parentBirthday = input.Dequeue();
                    Parent parent = new Parent(parentName, parentBirthday);

                    person.UpdatePerson(parent);
                    break;

                case "children":
                    string childName = input.Dequeue();
                    string childBirthday = input.Dequeue();
                    Child child = new Child(childName, childBirthday);

                    person.UpdatePerson(child);
                    break;
            }

            if (!peoples.Exists(p => p.Name == person.Name))
                peoples.Add(person);
        }
        string target = Console.ReadLine();
        var personToPrint = peoples.First(p => p.Name == target);

        Console.WriteLine(personToPrint);
    }

    private class Person
    {
        private string _name;
        private Car _car = new Car();
        private Company _company = new Company();
        private List<Child> _children = new List<Child>();
        private List<Parent> _parents = new List<Parent>();
        private List<Pokemon> _pokemons = new List<Pokemon>();

        public Person(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void UpdatePerson(Car car)
        {
            _car.Model = car.Model;
            _car.Speed = car.Speed;
        }

        public void UpdatePerson(Company company)
        {
            _company.Name = company.Name;
            _company.Department = company.Department;
            _company.Salary = company.Salary;
        }

        public void UpdatePerson(Child child)
        {
            _children.Add(child);
        }

        public void UpdatePerson(Parent parent)
        {
            _parents.Add(parent);
        }

        public void UpdatePerson(Pokemon pokemon)
        {
            _pokemons.Add(pokemon);
        }

        public override string ToString()
        {
            string pokemons = string.Join("\n", _pokemons);
            string parents = string.Join("\n", _parents);
            string children = string.Join("\n", _children);
            return
                $"{_name}" +
                $"\nCompany:\n{_company}".TrimEnd() +
                $"\nCar:\n{_car}\n".TrimEnd() +
                $"\nPokemon:\n{pokemons}".TrimEnd() +
                $"\nParents:\n{parents}".TrimEnd() +
                $"\nChildren:\n{children}".TrimEnd();
        }
    }

    private class Company
    {
        private string _name;
        private string _department;
        private decimal _salary;


        public Company(string name, string department, decimal salary)
        {
            _name = name;
            _department = department;
            _salary = salary;
        }

        public Company()
        {
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public override string ToString()
        {
            dynamic salary = _salary == 0 ? (dynamic)"" : _salary;
            return $"{_name} {_department} {salary:F2}";
        }
    }

    private class Car
    {
        private string _model;
        private int _speed;

        public Car(string model, int speed)
        {
            _model = model;
            _speed = speed;
        }

        public Car()
        {
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public override string ToString()
        {
            dynamic speed = _speed == 0 ? (dynamic)"" : _speed;
            return $"{_model} {speed}";
        }
    }

    private class Parent
    {
        private string _name;
        private string _birthday;

        public Parent(string name, string birthday)
        {
            _name = name;
            _birthday = birthday;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public override string ToString()
        {

            return $"{_name} {_birthday}";
        }
    }

    private class Child
    {
        private string _name;
        private string _birthday;

        public Child(string name, string birthday)
        {
            _name = name;
            _birthday = birthday;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public override string ToString()
        {
            return $"{_name} {_birthday}";
        }
    }

    private class Pokemon
    {
        private string _name;
        private string _type;


        public Pokemon(string name, string type)
        {
            _name = name;
            _type = type;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public override string ToString()
        {
            return $"{_name} {_type}";
        }
    }
}
