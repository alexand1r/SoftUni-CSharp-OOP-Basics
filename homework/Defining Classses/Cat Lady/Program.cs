using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat_Lady
{
    class Program
    {
        public static void Main()
        {
            var cats = new HashSet<Cat>();
            Cat cat;

            while (true)
            {
                var input = Console.ReadLine().Trim();

                if (input.ToLower() == "end")
                    break;

                var info = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var breed = info[0];
                var name = info[1];


                switch (breed)
                {
                    case "Cymric":
                        cat = new Cymric(name, double.Parse(info[2]));
                        break;
                    case "Siamese":
                        cat = new Siamese(name, int.Parse(info[2]));
                        break;
                    default:
                        cat = new StreetExtraordinaire(name, int.Parse(info[2]));
                        break;
                }

                cats.Add(cat);
            }

            var target = Console.ReadLine().Trim();
            cat = cats.First(x => x.Name.Equals(target));

            Console.WriteLine(cat);
        }

        private abstract class Cat
        {
            public string Name { get; private set; }

            protected Cat(string name)
            {
                this.Name = name;
            }
        }

        private class Siamese : Cat
        {
            private int EarSize { get; }

            public Siamese(string name, int earSize) : base(name)
            {
                this.EarSize = earSize;
            }

            public override string ToString()
            {
                return this.GetType().Name + " " + this.Name + " " + this.EarSize;
            }
        }

        private class Cymric : Cat
        {
            private double FurLength { get; }

            public Cymric(string name, double furLength) : base(name)
            {
                this.FurLength = furLength;
            }

            public override string ToString()
            {
                return $"{this.GetType().Name} {this.Name} {this.FurLength:F2}";
            }
        }

        private class StreetExtraordinaire : Cat
        {
            private int DecibelsOfMeow { get; }

            public StreetExtraordinaire(string name, int decibelOfMewo) : base(name)
            {
                this.DecibelsOfMeow = decibelOfMewo;
            }

            public override string ToString()
            {
                return this.GetType().Name + " " + this.Name + " " + this.DecibelsOfMeow;
            }
        }
    }
}
