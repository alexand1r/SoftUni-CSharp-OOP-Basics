using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

public class SonicHarvester : Harvester
{
    private int sonicFactor;
    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement)
    {
        base.EnergyRequirement /= (double) sonicFactor;
    }

    public int SonicFactor
    {
        get { return this.sonicFactor; }
        private set { this.sonicFactor = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.GetType().Name.Substring(0, 5)} Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.AppendLine($"Energy Requirement: {this.EnergyRequirement}");

        return sb.ToString().Trim();
    }
}
