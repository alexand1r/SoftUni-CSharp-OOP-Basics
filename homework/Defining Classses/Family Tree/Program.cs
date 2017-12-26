using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Program
{
    private static Regex rgxInputOne = new Regex(@"^(?<f1>\w+?)\s+(?<l1>\w+?)\s+-\s+(?<f2>\w+?)\s+(?<l2>\w+)$");
    private static Regex rgxInputTwo = new Regex(@"^(?<f>\w+?)\s+(?<l>\w+?)\s+-\s+(?<date>\d+\/\d+\/\d+)$");
    private static Regex rgxInputThree = new Regex(@"^(?<date>\d+\/\d+\/\d+)\s+-\s+(?<f>\w+?)\s+(?<l>\w+)$");
    private static Regex rgxInputFour = new Regex(@"^(?<date1>\d+\/\d+\/\d+)\s+-\s+(?<date2>\d+\/\d+\/\d+)$");
    private static Regex rgxInputFive = new Regex(@"^(?<f>\w+?)\s+(?<l>\w+?)\s+(?<date>\d+\/\d+\/\d+)$");

    private static HashSet<Person> People;

    public static void Main()
    {
        var target = Console.ReadLine().Trim();

        var ties = new List<string>();
        var creation = new List<string>();
        People = new HashSet<Person>();

        while (true)
        {
            var temp = Console.ReadLine().Trim();

            if (temp.ToLower().Equals("end"))
                break;

            if (!rgxInputFive.IsMatch(temp))
                ties.Add(temp);
            else
                creation.Add(temp);
        }

        foreach (var input in creation)
            Creation(input);

        foreach (var tie in ties)
            Tie(tie);

        var result = People.First(x => target.Any(y => y == '/')
            ? x.Birthday.Equals(target)
            : x.Name.Equals(target));

        Console.WriteLine(result);
        Console.WriteLine(result.FamilyTree);
    }

    private static void Creation(string input)
    {
        var match = rgxInputFive.Match(input);

        var firstName = match.Groups["f"].Value;
        var lastName = match.Groups["l"].Value;
        var birthday = match.Groups["date"].Value;

        People.Add(new Person(firstName, lastName, birthday));
    }

    private static void Tie(string input)
    {
        Person parent, child;
        string parentFirstName, parentLastName, parentBirthday;
        string childFirstName, childLastName, childBirthday;
        Match match;

        if (rgxInputOne.IsMatch(input))
        {
            match = rgxInputOne.Match(input);

            parentFirstName = match.Groups["f1"].Value;
            parentLastName = match.Groups["l1"].Value;

            childFirstName = match.Groups["f2"].Value;
            childLastName = match.Groups["l2"].Value;

            parent = People.First(x => x.Name == parentFirstName + " " + parentLastName);
            child = People.First(x => x.Name == childFirstName + " " + childLastName);
        }
        else if (rgxInputTwo.IsMatch(input))
        {
            match = rgxInputTwo.Match(input);

            parentFirstName = match.Groups["f"].Value;
            parentLastName = match.Groups["l"].Value;

            childBirthday = match.Groups["date"].Value;

            parent = People.First(x => x.Name == parentFirstName + " " + parentLastName);
            child = People.First(x => x.Birthday.Equals(childBirthday));
        }
        else if (rgxInputThree.IsMatch(input))
        {
            match = rgxInputThree.Match(input);

            parentBirthday = match.Groups["date"].Value;

            childFirstName = match.Groups["f"].Value;
            childLastName = match.Groups["l"].Value;

            parent = People.First(x => x.Birthday.Equals(parentBirthday));
            child = People.First(x => x.Name == childFirstName + " " + childLastName);

        }
        else
        {
            match = rgxInputFour.Match(input);

            parentBirthday = match.Groups["date1"].Value;

            childBirthday = match.Groups["date2"].Value;

            parent = People.First(x => x.Birthday.Equals(parentBirthday));
            child = People.First(x => x.Birthday.Equals(childBirthday));
        }

        parent.FamilyTree.AddChild(child);
        child.FamilyTree.AddParent(parent);
    }
}