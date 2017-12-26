using System;
using System.Text;

public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
    }

    public override double EnergyRequirement
    {
        protected set
        {
            base.EnergyRequirement = (double)value + (double)value;
        }
    }

    public override double OreOutput
    {
        protected set
        {
            base.OreOutput = (double)value + (double)(value * 2.0);
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.GetType().Name.Substring(0, 6)} Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.AppendLine($"Energy Requirement: {this.EnergyRequirement}");

        return sb.ToString().Trim();
    }
}
