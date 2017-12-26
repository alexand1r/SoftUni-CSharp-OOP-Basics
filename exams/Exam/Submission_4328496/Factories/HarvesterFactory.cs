﻿using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester CreateHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);

        if (type == "Sonic")
        {
            int sonicFactor = int.Parse(arguments[4]);
            return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
        }
        else
        {
            return new HammerHarvester(id, oreOutput, energyRequirement);
        }
    }

    //public HammerHarvester CreateHammerHarvester(List<string> arguments)
    //{
    //    string type = arguments[0];
    //    string id = arguments[1];
    //    double oreOutput = double.Parse(arguments[2]);
    //    double energyRequirement = double.Parse(arguments[3]);

    //    return new HammerHarvester(id, oreOutput, energyRequirement);
    //}
}