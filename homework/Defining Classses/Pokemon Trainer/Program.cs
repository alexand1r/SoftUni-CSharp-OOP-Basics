using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Queue<string> input = new Queue<string>(Console.ReadLine().Split());


            if (input.Peek().ToLower() == "tournament")
            {
                while (true)
                {
                    string fight = Console.ReadLine().ToLower();

                    if (fight == "end")
                        break;

                    Trainer.Tournament(fight);

                }

                break;
            }

            string trainerName = input.Dequeue();
            string pokemonName = input.Dequeue();
            string pokemonElement = input.Dequeue();
            int pokemonHealth = Convert.ToInt32(input.Dequeue());
            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if (!Trainer.Exist(trainerName))
            {
                new Trainer(trainerName)
                    .CatchPokemon(pokemon);
            }
            else
            {
                Trainer.FindTrainer(trainerName)
                    .CatchPokemon(pokemon);
            }

        }

        Trainer.PrintTrainersStats();
    }

    private class Trainer
    {
        private string _name;
        private int _numBadges = 0;
        private List<Pokemon> _pokemons = new List<Pokemon>();
        public static List<Trainer> _trainers = new List<Trainer>();

        public Trainer(string name, int numBadges)
        {
            _name = name;
            _numBadges = numBadges;
        }

        public Trainer(string name)
        {
            _name = name;
            _trainers.Add(new Trainer(_name, _numBadges));
        }

        public void CatchPokemon(Pokemon pokemon)
        {
            var trainer = _trainers.First(t => t._name == _name);
            trainer._pokemons.Add(pokemon);
        }

        public static bool Exist(string name)
        {
            return _trainers.FirstOrDefault(t => t._name == name) != null;
        }

        public static Trainer FindTrainer(string name)
        {
            return _trainers.FirstOrDefault(t => t._name == name);
        }

        public static void Tournament(string element)
        {
            foreach (Trainer trainer in _trainers)
            {
                bool hasPokemonWithElement = false;
                var pokemons = trainer._pokemons.GetEnumerator();

                while (pokemons.MoveNext())
                {
                    var current = pokemons.Current;
                    if (current.Element.ToLower().Equals(element))
                    {
                        hasPokemonWithElement = true;
                        break;
                    }
                }
                pokemons.Dispose();
                if (hasPokemonWithElement)
                {
                    trainer.AddBadge();
                }
                else
                {
                    trainer._pokemons.ForEach(p => p.TakeDamage());
                }
            }
            _trainers.ForEach(t => t._pokemons.RemoveAll(p => p.Health <= 0));

        }

        private void AddBadge()
        {
            _numBadges += 1;
        }

        public static void PrintTrainersStats()
        {

            _trainers
                .OrderByDescending(t => t._numBadges)
                .ToList()
                .ForEach(t => Console.WriteLine($"{t._name} {t._numBadges} {t._pokemons.Count}"));
        }
    }

    private class Pokemon
    {
        private string _name;
        private string _element;
        private int _health;

        public Pokemon(string name, string element, int health)
        {
            _name = name;
            _element = element;
            _health = health;
        }

        public string Element
        {
            get { return _element; }
            set { _element = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public void TakeDamage()
        {
            _health -= 10;
        }
    }
}
