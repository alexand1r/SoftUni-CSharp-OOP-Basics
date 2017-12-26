using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

public class AdoptionCenter : Center
{
    private List<Animal> adoptedAnimals;
    private List<Animal> animalsSentForCleansing;
    public AdoptionCenter(string name)
        : base(name)
    {
        this.AdoptedAnimals = new List<Animal>();
        this.AnimalsSentForCleansing = new List<Animal>();
    }

    public List<Animal> AdoptedAnimals
    {
        get { return this.adoptedAnimals; }
        private set { this.adoptedAnimals = value; }
    }

    private List<Animal> AnimalsSentForCleansing
    {
        get { return this.animalsSentForCleansing; }
        set { this.animalsSentForCleansing = value; }
    }

    public void SendAnimalsForCleansing()
    {
        List<Animal> animalsToRemove = new List<Animal>();
        foreach (var animal in this.StoredAnimals)
        {
            if (!animal.IsCleansed)
            {
                this.AnimalsSentForCleansing.Add(animal);
                animalsToRemove.Add(animal);
            }
        }

        foreach (var animal in animalsToRemove)
        {
            this.StoredAnimals.Remove(animal);
        }
    }

    public void TakeBackCleansedAnimals()
    {
        List<Animal> animalsToRemove = new List<Animal>();
        foreach (var animal in this.AnimalsSentForCleansing)
        {
            if (animal.IsCleansed)
            {
                this.StoredAnimals.Add(animal);
                animalsToRemove.Add(animal);
            }
        }

        foreach (var animal in animalsToRemove)
        {
            this.AnimalsSentForCleansing.Remove(animal);
        }
    }

    public void Adopt()
    {
        List<Animal> animalsToRemove = new List<Animal>();
        foreach (var animal in this.StoredAnimals)
        {
            if (animal.IsCleansed)
            {
                this.AdoptedAnimals.Add(animal);
                animalsToRemove.Add(animal);
            }
        }

        foreach (var animal in animalsToRemove)
        {
            this.StoredAnimals.Remove(animal);
        }
    }
}
