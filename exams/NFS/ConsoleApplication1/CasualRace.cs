using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    public class CasualRace : Race
    {
    public CasualRace(int length, string route, int prizePool, ICollection<Car> cars) : base(length, route, prizePool, cars)
    {
    }

    public override string ToString()
        {
            var dict = new Dictionary<Car, int>();
            foreach (var car in this.Participants)
            {
                var OP = (car.HorsePower / car.Acceleration) + (car.Suspension + car.Durability);
                dict.Add(car, OP);
            }
            var ordered = dict.OrderByDescending(x => x.Value).Take(3);
            var result = "";
            var counter = 1;
            foreach (var orderedItem in ordered)
            {
                var moneyWon = 0;
                if (counter == 1)
                {
                    moneyWon = (int)(0.5 * this.PrizePool);
                }
                else if (counter == 2)
                {
                    moneyWon = (int)(0.3 * this.PrizePool);
                }
                else if (counter == 3)
                {
                    moneyWon = (int)(0.2 * this.PrizePool);
                }

                result += $"\n{counter}. {orderedItem.Key.Brand} {orderedItem.Key.Model} {orderedItem.Value}PP - ${moneyWon}";
                counter++;
            }

            return base.ToString() + $"{result}";
        }
    }