using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Animal
{
    private int age;
    private string name;
    private bool isCleansed;

    public Animal(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.IsCleansed = false;
    }

    public string Name
    {
        get { return this.name; }
        protected set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException();

            foreach (char ch in value)
            {
                if (!isAsciiPrintable(ch))
                    throw new ArgumentException();
            }

            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        protected set { this.age = value; }
    }

    public bool IsCleansed
    {
        get { return this.isCleansed; }
        set { this.isCleansed = value; }
    }

    private bool isAsciiPrintable(char ch)
    {
        return ch >= 32 && ch < 127;
    }
}
