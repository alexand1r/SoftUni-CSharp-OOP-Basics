using System;

class Product
{
    private string _name;
    private decimal _cost;

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

    public decimal Cost
    {
        get { return _cost; }
        private set
        {
            if (value < 0)
                throw new ArgumentException("Money cannot be negative");

            _cost = value;
        }
    }

    public override string ToString()
    {
        return this.Name;
    }

    public Product(string name, decimal cost)
    {
        this.Name = name;
        this.Cost = cost;
    }
}
