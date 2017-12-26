using System;
using System.Linq;

public class Engine
{
    private NationsBuilder nationsBuilder;
    public Engine()
    {
        this.nationsBuilder = new NationsBuilder();
    }

    public void Run()
    {
        string input = string.Empty;

        while ((input = Console.ReadLine()) != "Quit")
            ExecuteCommand(input);

        Console.WriteLine(nationsBuilder.GetWarsRecord());
    }

    private void ExecuteCommand(string input)
    {
        string[] data = input
            .Split(new char[] {' '}
            , StringSplitOptions.RemoveEmptyEntries);

        switch (data[0])
        {
            case "Bender":
                nationsBuilder.AssignBender(data.Skip(1).ToList());
                break;
            case "Monument":
                nationsBuilder.AssignMonument(data.Skip(1).ToList());
                break;
            case "War":
                nationsBuilder.IssueWar(data[1]);
                break;
            case "Status":
                Console.Write(nationsBuilder.GetStatus(data[1]));
                break;
        }
    }
}
