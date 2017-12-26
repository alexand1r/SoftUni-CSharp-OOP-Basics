using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StartUp
{
    static void Main(string[] args)
    {
        var cleansingCenters = new Dictionary<string, CleansingCenter>();
        var adoptionCenters = new Dictionary<string, AdoptionCenter>();

        string cmd = Console.ReadLine();
        while (!cmd.Equals("Paw Paw Pawah"))
        {
            string[] data = cmd.Split(" | ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string command = data[0];
            string[] input = data.Skip(1).ToArray();
            switch (command)
            {
                case "RegisterCleansingCenter":
                    cleansingCenters.Add(input[0], new CleansingCenter(input[0]));
                    break;
                case "RegisterAdoptionCenter":
                    adoptionCenters.Add(input[0], new AdoptionCenter(input[0]));
                    break;
                case "RegisterCat":
                {
                    adoptionCenters[input[3]].StoredAnimals
                        .Add(new Cat(input[0], int.Parse(input[1]), int.Parse(input[2])));
                    break;
                }
                case "RegisterDog":
                {
                    adoptionCenters[input[3]].StoredAnimals
                        .Add(new Dog(input[0], int.Parse(input[1]), int.Parse(input[2])));
                    break;
                }
                case "SendForCleansing":
                {
                    cleansingCenters[input[1]]
                            .StoredAnimals
                            .AddRange(adoptionCenters[input[0]]
                            .StoredAnimals
                            .Where(sa => !sa.IsCleansed));
                    adoptionCenters[input[0]].SendAnimalsForCleansing();
                    break;
                }
                case "Cleanse":
                {
                    cleansingCenters[input[0]].Cleanse();
                    foreach (var adoptionCenter in adoptionCenters)
                    {
                        adoptionCenter.Value.TakeBackCleansedAnimals();
                    }
                    break;
                }
                case "Adopt":
                {
                    adoptionCenters[input[0]].Adopt();
                    break;
                }
            }

            cmd = Console.ReadLine();
        }
            
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Paw Incorporative Regular Statistics");
        sb.AppendLine($"Adoption Centers: {adoptionCenters.Count}");
        sb.AppendLine($"Cleansing Centers: {cleansingCenters.Count}");
        sb.AppendLine($"Adopted Animals: {string.Join(", ", PrintAdoptedAnimals(adoptionCenters))}");
        sb.AppendLine($"Cleansed Animals: {string.Join(", ", PrintCleansedAnimals(cleansingCenters))}");
        sb.AppendLine($"Animals Awaiting Adoption: {adoptionCenters.Values.Sum(x => x.StoredAnimals.Count())}");
        sb.AppendLine($"Animals Awaiting Cleansing: {cleansingCenters.Values.Sum(x => x.StoredAnimals.Count())}");

        Console.WriteLine(sb.ToString());
    }

    private static List<string> PrintAdoptedAnimals(Dictionary<string, AdoptionCenter> adoptionCenters)
    {
        List<string> adoptedAnimals = new List<string>();
        foreach (var adoptionCenter in adoptionCenters.Values)
        {
            foreach (var animal in adoptionCenter.AdoptedAnimals)
            {
                adoptedAnimals.Add(animal.Name);
            }
        }

        if (adoptedAnimals.Count == 0)
            adoptedAnimals.Add("None");

        return adoptedAnimals.OrderBy(x => x).ToList();
    }

    private static List<string> PrintCleansedAnimals(Dictionary<string, CleansingCenter> cleansingCenters)
    {
        List<string> cleansedAnimals = new List<string>();
        foreach (var cleansingCenter in cleansingCenters.Values)
        {
            foreach (var animal in cleansingCenter.CleansedAnimals)
            {
                cleansedAnimals.Add(animal.Name);
            }
        }

        if (cleansedAnimals.Count == 0)
            cleansedAnimals.Add("None");

        return cleansedAnimals.OrderBy(x => x).ToList();
    }
}


