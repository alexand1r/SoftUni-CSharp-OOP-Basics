using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public abstract class Center
{
    private string name;
    private List<Animal> storedAnimals;

    protected Center(string name)
    {
        this.Name = name;
        this.StoredAnimals = new List<Animal>();
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

    public List<Animal> StoredAnimals
    {
        get { return this.storedAnimals; }
        private set { this.storedAnimals = value; }
    }

    private bool isAsciiPrintable(char ch)
    {
        return ch >= 32 && ch < 127;
    }
}
