using System;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;
    public Engine()
    {
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        string input = string.Empty;

        while ((input = Console.ReadLine()) != "Shutdown")
            ExecuteCommand(input);

        Console.Write(draftManager.ShutDown());
    }

    private void ExecuteCommand(string input)
    {
        string[] data = input
            .Split(new char[] { ' ' }
                , StringSplitOptions.RemoveEmptyEntries);

        switch (data[0])
        {
            case "RegisterHarvester":
                Console.WriteLine(draftManager.RegisterHarvester(data.Skip(1).ToList()));
                break;
            case "RegisterProvider":
                Console.WriteLine(draftManager.RegisterProvider(data.Skip(1).ToList()));
                break;
            case "Day":
                Console.WriteLine(draftManager.Day());
                break;
            case "Mode":
                Console.WriteLine(draftManager.Mode(data.Skip(1).ToList()));
                break;
            case "Check":
                Console.WriteLine(draftManager.Check(data.Skip(1).ToList()));
                break;
        }
    }
}
