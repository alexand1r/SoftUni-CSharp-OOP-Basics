using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    public abstract class Race
    {
        public Race(int length, string route, int prizePool, ICollection<Car> cars)
        {
            this.Participants = new List<Car>();
        }
        public int Length { get; set; }
        public string Route { get; set; }
        public int PrizePool { get; set; }
        public ICollection<Car> Participants { get; set; }

        public override string ToString()
        {
            return $"{this.Route} - {this.Length}";
        }
    }