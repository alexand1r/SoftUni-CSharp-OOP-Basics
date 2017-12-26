using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Animal
{
    protected string name;
    protected string favouriteFood;

    public Animal(string name, string favouriteFood)
    {
        this.name = name;
        this.favouriteFood = favouriteFood;
    }

    public virtual string ExplainMyself()
    {
        return $"I am {this.name} and my fovourite food is {this.favouriteFood}";
    }
}

public class Cat : Animal
{
    public Cat(string name, string favouriteFood) 
        : base(name, favouriteFood)
    {
    }

    public override string ExplainMyself()
    {
        return base.ExplainMyself() + Environment.NewLine + "MEEOW";
    }
}
public class Dog : Animal
{
    public Dog(string name, string favouriteFood)
        : base(name, favouriteFood)
    {
    }

    public override string ExplainMyself()
    {
        return base.ExplainMyself() + Environment.NewLine + "DJAAF";
    }
}
class Program
{
    static void Main(string[] args)
    {
        var animals = new List<Animal>();
        animals.Add(new Cat("Pesho", "Whiskas"));
        animals.Add(new Dog("Gosho", "Meat"));

        foreach (var animal in animals)
        {
            Console.WriteLine(animal.ExplainMyself());
        }
    }
}
