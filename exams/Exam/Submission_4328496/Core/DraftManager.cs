using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private string currentMode;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    public DraftManager()
    {
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
        this.Harvesters = new Dictionary<string, Harvester>();
        this.Providers = new Dictionary<string, Provider>();
        this.TotalMinedOre= 0.0;
        this.TotalStoredEnergy = 0.0;
        this.CurrentMode = "Full";
    }

    public HarvesterFactory HarvesterFactory
    {
        get { return this.harvesterFactory; }
        set { this.harvesterFactory = value; }
    }

    public ProviderFactory ProviderFactory
    {
        get { return this.providerFactory; }
        set { this.providerFactory = value; }
    }

    public string CurrentMode
    {
        get { return this.currentMode; }
        private set { this.currentMode = value; }
    }

    public double TotalStoredEnergy
    {
        get { return this.totalStoredEnergy; }
        private set { this.totalStoredEnergy = value; }
    }

    public double TotalMinedOre
    {
        get { return this.totalMinedOre; }
        private set { this.totalMinedOre = value; }
    }

    public Dictionary<string, Harvester> Harvesters
    {
        get { return this.harvesters; }
        private set { this.harvesters = value; }
    }

    public Dictionary<string, Provider> Providers
    {
        get { return this.providers; }
        private set { this.providers = value; }
    }

    public string RegisterHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        //double oreOutput = double.Parse(arguments[2]);
        //double energyRequirement = double.Parse(arguments[3]);

        try
        {
            //if (type == "Hammer")
            //    //this.Harvesters.Add(id, new HammerHarvester(id, oreOutput, energyRequirement));
            //    this.Harvesters.Add(id, this.HarvesterFactory.CreateHarvester(arguments));
            //else
            //{
            //    //int sonicFactor = int.Parse(arguments[4]);
            //    //this.Harvesters.Add(id, new SonicHarvester(sonicFactor, id, oreOutput, energyRequirement));
            //    this.Harvesters.Add(id, this.HarvesterFactory.CreateHarvester(arguments));
            //}
            this.Harvesters.Add(id, this.HarvesterFactory.CreateHarvester(arguments));
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }

        return $"Successfully registered {type} Harvester - {id}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyRequirement = double.Parse(arguments[2]);

        try
        {
            this.Providers.Add(id, this.providerFactory.CreateProvider(arguments));
            //if (type == "Solar")
            //    this.Providers.Add(id, this.providerFactory.CreateProvider(arguments));
            ////Providers.Add(id, new SolarProvider(id, energyRequirement));
            //else
            //    this.Providers.Add(id, this.providerFactory.CreateProvider(arguments));
            ////Providers.Add(id, new PressureProvider(id, energyRequirement));
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }

        return $"Successfully registered {type} Provider - {id}";
    }

    public string Day()
    {
        double allHarvestersEnergy = 0.0;
        double allHarverstersOreOutput = 0.0;

        double allProvidersEnergy = Providers.Sum(x => x.Value.EnergyOutput);
        this.TotalStoredEnergy += allProvidersEnergy;

        if (this.CurrentMode == "Full")
        {
            allHarvestersEnergy += Harvesters.Sum(x => x.Value.EnergyRequirement);
            allHarverstersOreOutput += Harvesters.Sum(x => x.Value.OreOutput);    
        }
        else if (this.CurrentMode == "Half")
        {
            allHarvestersEnergy += Harvesters.Sum(x => x.Value.EnergyRequirement * 0.6);
            allHarverstersOreOutput += Harvesters.Sum(x => x.Value.OreOutput * 0.5);
        }

        if (this.TotalStoredEnergy >= allHarvestersEnergy)
        {
            this.TotalStoredEnergy -= allHarvestersEnergy;
            this.TotalMinedOre += allHarverstersOreOutput;
        }
        else
            allHarverstersOreOutput = 0;

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {allProvidersEnergy}");
        sb.AppendLine($"Plumbus Ore Mined: {allHarverstersOreOutput}");

        return sb.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        string mode = arguments[0];
        this.CurrentMode = mode;

        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        foreach (var harvester in this.Harvesters)
        {
            if (harvester.Key == id)
                return harvester.Value.ToString();
        }

        foreach (var provider in this.Providers)
        {
            if (provider.Key == id)
                return provider.Value.ToString();
        }
            
        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.TotalStoredEnergy}");
        sb.AppendLine($"Total Mined Plumbus Ore: {this.TotalMinedOre}");
       
        return sb.ToString().Trim();
    }
}
