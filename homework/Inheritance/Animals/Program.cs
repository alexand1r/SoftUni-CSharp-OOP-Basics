using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Animal
{
    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Genger = gender;
    }

    public string Name
    {
        get => this.name;
        protected set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            this.name = value;
        }
    }

    public int Age
    {
        get => this.age;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value.ToString()) || value < 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            this.age = value;
        }
    }

    public string Genger
    {
        get => this.gender;
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            this.gender = value;
        }
    }

    public abstract string ProduceSound();
    public abstract string IntroduceAnimal();
}

public class Dog : Animal
{
    public Dog(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string IntroduceAnimal()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{typeof(Dog)}")
            .Append($"{base.Name} {base.Age} {base.Genger}");
        return sb.ToString();
    }

    public override string ProduceSound()
    {
        return "BauBau";
    }
}

public class Cat : Animal
{
    public Cat(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string IntroduceAnimal()
    {
        return $"{typeof(Cat)}" + Environment.NewLine + $"{base.Name} {base.Age} {base.Genger}";
    }

    public override string ProduceSound()
    {
        return "MiauMiau";
    }
}

public class Frog : Animal
{
    public Frog(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string IntroduceAnimal()
    {
        return $"{typeof(Frog)}" + Environment.NewLine + $"{base.Name} {base.Age} {base.Genger}";
    }

    public override string ProduceSound()
    {
        return "Frogggg";
    }
}

public class Kitten : Animal
{
    public Kitten(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string IntroduceAnimal()
    {
        return $"{typeof(Kitten)}" + Environment.NewLine + $"{base.Name} {base.Age} {base.Genger}";
    }

    public override string ProduceSound()
    {
        return "Miau";
    }
}

public class Tomcat : Animal
{
    public Tomcat(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string IntroduceAnimal()
    {
        return $"{typeof(Tomcat)}" + Environment.NewLine + $"{base.Name} {base.Age} {base.Genger}";

    }

    public override string ProduceSound()
    {
        return "Give me one million b***h";
    }
}

public class Animals
{
    public static void Main()
    {
        var animals = new List<Animal>();

        string kindOfAnimal;
        while ((kindOfAnimal = Console.ReadLine()) != "Beast!")
        {
            var animalTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                switch (kindOfAnimal.ToLower().Trim())
                {
                    case "cat":
                        Animal cat = new Cat(animalTokens[0], int.Parse(animalTokens[1]), animalTokens[2]);
                        animals.Add(cat);
                        break;
                    case "dog":
                        Animal dog = new Dog(animalTokens[0], int.Parse(animalTokens[1]), animalTokens[2]);
                        animals.Add(dog);
                        break;

                    case "frog":
                        Animal frog = new Frog(animalTokens[0], int.Parse(animalTokens[1]), animalTokens[2]);
                        animals.Add(frog);
                        break;

                    case "kitten":
                        Animal kitten = new Kitten(animalTokens[0], int.Parse(animalTokens[1]), "Female");
                        animals.Add(kitten);
                        break;

                    case "tomcat":
                        Animal tomcat = new Tomcat(animalTokens[0], int.Parse(animalTokens[1]), "Male");
                        animals.Add(tomcat);
                        break;

                    default:
                        Console.WriteLine("Invalid input!");
                        break;

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
        }

        foreach (var an in animals)
        {
            Console.WriteLine(an.IntroduceAnimal());
            Console.WriteLine(an.ProduceSound());
        }
    }
}
