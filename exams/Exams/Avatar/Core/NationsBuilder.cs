using System;
using System.Collections.Generic;
using System.Text;

public class NationsBuilder
{
    private Nation airNation;
    private Nation waterNation;
    private Nation earthNation;
    private Nation fireNation;
    private List<string> wars;
    private List<Nation> Nations;
    public NationsBuilder()
    {
        this.airNation = new AirNation();
        this.fireNation = new FireNation();
        this.earthNation = new EarthNation();
        this.waterNation = new WaterNation();
        this.wars = new List<string>();
        this.Nations = new List<Nation>(){this.airNation, this.earthNation, this.fireNation, this.waterNation};
    }

    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        string name = benderArgs[1];
        int power = int.Parse(benderArgs[2]);
        double secondaryParam = double.Parse(benderArgs[3]);

        switch (type)
        {
            case "Air":
                airNation.Benders.Add(new AirBender(name, power, secondaryParam));
                break;
            case "Water":
                waterNation.Benders.Add(new WaterBender(name, power, secondaryParam));
                break;
            case "Earth":
                earthNation.Benders.Add(new EarthBender(name, power, secondaryParam));
                break;
            case "Fire":
                fireNation.Benders.Add(new FireBender(name, power, secondaryParam));
                break;
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        string name = monumentArgs[1];
        int affinity = int.Parse(monumentArgs[2]);

        switch (type)
        {
            case "Air":
                airNation.Monuments.Add(new AirMonument(name, affinity));
                break;
            case "Water":
                waterNation.Monuments.Add(new WaterMonument(name, affinity));
                break;
            case "Earth":
                earthNation.Monuments.Add(new EarthMonument(name, affinity));
                break;
            case "Fire":
                fireNation.Monuments.Add(new FireMonument(name, affinity));
                break;
        }
    }

    public string GetStatus(string nationsType)
    {
        switch (nationsType)
        {
            case "Air":
                return airNation.ToString();
            case "Water":
                return waterNation.ToString();
            case "Earth":
                return earthNation.ToString();
            case "Fire":
                return fireNation.ToString();
            default:
                return "";
        }
    }
    public void IssueWar(string nationsType)
    {
        wars.Add(nationsType);

        var max = double.MinValue;
        foreach (var nation in this.Nations)
        {
            var totalPower = nation.GetTotalPower();
            if (totalPower > max) max = totalPower;
        }

        foreach (var nation in this.Nations)
        {
            if (nation.GetTotalPower() != max)
            {
                nation.Benders.Clear();
                nation.Monuments.Clear();
            }
        }
    }

    public string GetWarsRecord()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < wars.Count; i++)
        {
            sb.AppendLine($"War {i + 1} issued by {wars[i]}");
        }

        return sb.ToString();
    }
}

