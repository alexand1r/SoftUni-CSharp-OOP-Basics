using System.Collections.Generic;

public class ProviderFactory
{
    public Provider CreateProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyRequirement = double.Parse(arguments[2]);

        if (type == "Pressure")
        {
            return new PressureProvider(id, energyRequirement);
        }
        else
        {
            return new SolarProvider(id, energyRequirement);
        }
    }

    //public SolarProvider CreateSolarProvider(List<string> arguments)
    //{
    //    string type = arguments[0];
    //    string id = arguments[1];
    //    double energyRequirement = double.Parse(arguments[2]);

    //    return new SolarProvider(id, energyRequirement);
    //}
}
