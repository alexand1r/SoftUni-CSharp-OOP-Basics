using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CleansingCenter : Center
{
    private List<Animal> cleansedAnimals;
    public CleansingCenter(string name) :
        base(name)
    {
        this.CleansedAnimals = new List<Animal>();
    }

    public List<Animal> CleansedAnimals
    {
        get { return this.cleansedAnimals; }
        private set { this.cleansedAnimals = value; }
    }

    public void Cleanse()
    {
        foreach (var storedAnimal in this.StoredAnimals)
        {
            storedAnimal.IsCleansed = true;
            this.CleansedAnimals.Add(storedAnimal);
        }

        this.StoredAnimals.Clear();
    }
}
