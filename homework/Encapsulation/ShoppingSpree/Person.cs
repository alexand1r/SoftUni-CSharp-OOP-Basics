using System;
using System.Collections.Generic;

class Person
{
    private string _name;
    private decimal _money;

    public string Name
    {
        get { return _name; }
        private set
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("Name cannot be empty");

            _name = value;
        }
    }

    private decimal Money
    {
        get { return _money; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Money cannot be negative");

            _money = value;
        }
    }

    private List<Product> Bag { get; }

    public void Buy(Product product)
    {
        if (this.Money < product.Cost)
        {
            Console.WriteLine($"{this.Name} can't afford {product.Name}");
            return;
        }

        this.Money -= product.Cost;
        this.Bag.Add(product);
        Console.WriteLine($"{this.Name} bought {product.Name}");
    }

    public override string ToString()
    {
        if (this.Bag.Count == 0)
            return $"{this.Name} - Nothing bought";

        return $"{this.Name} - {string.Join(", ", this.Bag)}";
    }

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.Bag = new List<Product>();
    }
}
