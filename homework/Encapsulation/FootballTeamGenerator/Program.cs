using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Team
{
    private string _name;
    public HashSet<Player> Players { get; }

    public string Name
    {
        get { return _name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("A name should not be empty.");

            _name = value;
        }
    }

    public int Rating
    {
        get
        {
            if (this.Players.Count == 0)
                return 0;

            return (int)Math.Round(this.Players.SelectMany(x => x.Stats.Select(y => y.Amount)).Average());
        }
    }

    public void AddPlayer(Player player)
    {
        this.Players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        var player = this.Players.FirstOrDefault(x => x.Name == playerName);

        if (player == null)
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");

        this.Players.Remove(player);
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Rating}";
    }

    public Team(string name)
    {
        this.Name = name;
        this.Players = new HashSet<Player>();
    }
}

public class Skill
{
    private int _amount;
    private SkillType Type { get; }

    public int Amount
    {
        get { return _amount; }
        private set
        {
            if (value < 0 || value > 100)
                throw new ArgumentException($"{this.Type} should be between 0 and 100.");

            this._amount = value;
        }
    }

    public Skill(SkillType skillType, int val)
    {
        this.Type = skillType;
        this.Amount = val;
    }

    public enum SkillType
    {
        Endurance = 0,
        Sprint = 1,
        Dribble = 2,
        Passing = 3,
        Shooting = 4
    }
}

public class Player
{
    private string _name;

    public string Name
    {
        get { return _name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("A name should not be empty.");

            _name = value;
        }
    }

    public List<Skill> Stats { get; }

    public Player(string name, List<Skill> stats)
    {
        this.Name = name;
        this.Stats = stats;
    }
}
public class Program
{
    public static void Main()
    {
        var teams = new HashSet<Team>();

        string teamName;

        while (true)
        {
            var input = Console.ReadLine().Trim().Split(';');

            if (input[0].Equals("end", StringComparison.OrdinalIgnoreCase))
                break;

            teamName = input[1];
            var team = teams.FirstOrDefault(x => x.Name.Equals(teamName));

            try
            {
                string playerName;

                if (!input[0].Equals("team", StringComparison.OrdinalIgnoreCase))
                    if (team == null)
                        throw new ArgumentException($"Team {teamName} does not exist.");

                if (input[0].Equals("add", StringComparison.OrdinalIgnoreCase))
                {
                    playerName = input[2];

                    var skills = (Skill.SkillType[])typeof(Skill.SkillType).GetEnumValues();

                    var playerSkills = new List<Skill>(skills.Length);

                    for (int i = 0; i < skills.Length; i++)
                    {
                        var val = int.Parse(input[i + 3]);
                        playerSkills.Add(new Skill(skills[i], val));
                    }

                    team.AddPlayer(new Player(playerName, playerSkills));
                }
                else if (input[0].Equals("remove", StringComparison.OrdinalIgnoreCase))
                {
                    playerName = input[2];

                    team.RemovePlayer(playerName);
                }
                else if (input[0].Equals("rating", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(team);
                }
                else
                {
                    team = new Team(teamName);
                    teams.Add(team);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        
        }
    }
}
