using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cat : Felime
{
    private string breed;
    public Cat(string animalType, string animalName, string breed, double animalWeight, string region, int foodEaten)
    {
        this.AnimalType = animalType;
        this.AnimalName = animalName;
        this.AnimalWeight = animalWeight;
        this.FoodEaten = foodEaten;
        this.Breed = breed;
        this.LivingRegion = region;
    }

    public string Breed
    {
        get { return this.breed; }
        private set { this.breed = value; }
    }

    public override void Eat(Food food)
    {
        this.FoodEaten += food.Quantity;
    }
    
    public override void MakeSound()
    {
        Console.WriteLine("Meowwww");
    }

    public override string ToString()
    {
        return $"{AnimalType}[{AnimalName}, {Breed}, {AnimalWeight}, {LivingRegion}, {FoodEaten}]";
    }
}

public class Tiger : Felime
{
    public Tiger(string animalType, string animalName, double animalWeight, string region, int foodEaten)
    {
        this.AnimalType = animalType;
        this.AnimalName = animalName;
        this.AnimalWeight = animalWeight;
        this.FoodEaten = foodEaten;
        this.LivingRegion = region;
    }

    public override void Eat(Food food)
    {
        if (food.GetType() == typeof(Meat))
            this.FoodEaten += food.Quantity;
        else
            throw new ArgumentException(
                $"{this.AnimalType}s are not eating that type of food!");
    }

    public override void MakeSound()
    {
        Console.WriteLine("ROAAR!!!");
    }

    public override string ToString()
    {
        return $"{AnimalType}[{AnimalName}, {AnimalWeight}, {LivingRegion}, {FoodEaten}]";
    }
}

public class Zebra : Mammal
{
    public Zebra(string animalType, string animalName, double animalWeight, string region, int foodEaten)
    {
        this.AnimalType = animalType;
        this.AnimalName = animalName;
        this.AnimalWeight = animalWeight;
        this.FoodEaten = foodEaten;
        this.LivingRegion = region;
    }

    public override void Eat(Food food)
    {
        if (food.GetType() == typeof(Vegitable))
            this.FoodEaten += food.Quantity;
        else
            throw new ArgumentException(
                $"{this.AnimalType}s are not eating that type of food!");
    }

    public override void MakeSound()
    {
        Console.WriteLine("Zs");
    }

    public override string ToString()
    {
        return $"{AnimalType}[{AnimalName}, {AnimalWeight}, {LivingRegion}, {FoodEaten}]";
    }
}

public class Mouse : Mammal
{
    public Mouse(string animalType, string animalName, double animalWeight, string region, int foodEaten)
    {
        this.AnimalType = animalType;
        this.AnimalName = animalName;
        this.AnimalWeight = animalWeight;
        this.FoodEaten = foodEaten;
        this.LivingRegion = region;
    }

    public override void Eat(Food food)
    {
        if (food.GetType() == typeof(Vegitable))
            this.FoodEaten += food.Quantity;
        else
            throw new ArgumentException(
                $"{this.AnimalType}s are not eating that type of food!");
    }

    public override void MakeSound()
    {
        Console.WriteLine("SQUEEEAAAK!");
    }

    public override string ToString()
    {
        return $"{AnimalType}[{AnimalName}, {AnimalWeight}, {LivingRegion}, {FoodEaten}]";
    }
}

public abstract class Felime : Mammal
{

}

public abstract class Mammal : Animal
{
    private string livingRegion;

    public string LivingRegion
    {
        get { return this.livingRegion; }
        protected set { this.livingRegion = value; }
    }
}

public abstract class Animal
{
    private string animalName;
    private string animalType;
    private double animalWeight;
    private int foodEaten;

    public string AnimalName
    {
        get { return this.animalName; }
        protected set { this.animalName = value; }
    }

    public string AnimalType
    {
        get { return this.animalType; }
        protected set { this.animalType = value; }
    }

    public double AnimalWeight
    {
        get { return this.animalWeight; }
        protected set { this.animalWeight = value; }
    }

    public int FoodEaten
    {
        get { return this.foodEaten; }
        protected set { this.foodEaten = value; }
    }

    public abstract void MakeSound();
    public abstract void Eat(Food food);
}

public class Meat : Food
{
    public Meat(int quantity)
    {
        base.Quantity = quantity;
    }
}

public class Vegitable : Food
{
    public Vegitable(int quantity)
    {
        base.Quantity = quantity;
    }
}

public abstract class Food
{
    private int quantity;

    public int Quantity
    {
        get { return this.quantity; }
        protected set { this.quantity = value; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Mammal> animals = new List<Mammal>();
        string cmd = Console.ReadLine();
        int line = 1;
        while (!cmd.Equals("End"))
        {
            string[] data = cmd.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (line % 2 != 0)
            {
                switch (data[0])
                {
                    case "Cat":
                        animals.Add(new Cat(data[0], data[1], data[4], double.Parse(data[2]), data[3], 0));
                        break;
                    case "Tiger":
                        animals.Add(new Tiger(data[0], data[1], double.Parse(data[2]), data[3], 0));
                        break;
                    case "Mouse":
                        animals.Add(new Mouse(data[0], data[1], double.Parse(data[2]), data[3], 0));
                        break;
                    case "Zebra":
                        animals.Add(new Zebra(data[0], data[1], double.Parse(data[2]), data[3], 0));
                        break;
                }
            }
            else
            {
                Food food;
                if (data[0] == "Vegetable")
                {
                    food = new Vegitable(int.Parse(data[1]));
                }
                else
                {
                    food = new Meat(int.Parse(data[1]));
                }
                Mammal last = animals.Last();
                last.MakeSound();
                try
                {
                    last.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                Console.WriteLine(last.ToString());
            }

            line++;
            cmd = Console.ReadLine();
        }
    }
}

//Cat Gray 1.1 Home Persian
//Vegetable 4
//End

//Tiger Typcho 167.7 Asia
//Vegetable 1
//End

//Zebra Doncho 500 Africa
//Vegetable 150
//End

//Mouse Jerry 0.5 Anywhere
//Vegetable 0
//End