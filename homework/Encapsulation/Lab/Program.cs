using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        //// Problem 1 
        //var lines = int.Parse(Console.ReadLine());
        //var persons = new List<Person>();
        //for (int i = 0; i < lines; i++)
        //{
        //    var cmdArgs = Console.ReadLine().Split();
        //    var person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));
        //    persons.Add(person);
        //}

        //persons.OrderBy(p => p.FirstName)
        //       .ThenBy(p => p.Age)
        //       .ToList()
        //       .ForEach(p => Console.WriteLine(p.ToString()));

        //// Problem 2
        //var lines = int.Parse(Console.ReadLine());
        //var persons = new List<Person>();
        //for (int i = 0; i < lines; i++)
        //{
        //    var cmdArgs = Console.ReadLine().Split();
        //    var person = new Person(cmdArgs[0],
        //                            cmdArgs[1],
        //                            int.Parse(cmdArgs[2]),
        //                            double.Parse(cmdArgs[3]));

        //    persons.Add(person);
        //}
        //var bonus = double.Parse(Console.ReadLine());
        //persons.ForEach(p => Console.WriteLine(p.ToString()));

        //// Problem 3
        //var lines = int.Parse(Console.ReadLine());
        //var persons = new List<Person>();
        //for (int i = 0; i < lines; i++)
        //{
        //    var cmdArgs = Console.ReadLine().Split();
        //    try
        //    {
        //        var person = new Person(cmdArgs[0],
        //                                cmdArgs[1],
        //                                int.Parse(cmdArgs[2]),
        //                                double.Parse(cmdArgs[3]));
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //persons.ForEach(p => Console.WriteLine(p.ToString()));

        //// Problem 4
        //var name = Console.ReadLine();
        var lines = int.Parse(Console.ReadLine());
        var team = new Team("team");

        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            var person = new Person(cmdArgs[0],
                                    cmdArgs[1],
                                    int.Parse(cmdArgs[2]),
                                    double.Parse(cmdArgs[3]));
            team.AddPlayer(person);
        }

        Console.WriteLine($"First team have {team.FirstTeam.Count} players");
        Console.WriteLine($"Reserve team have {team.ReserveTeam.Count} players");
    }
}
