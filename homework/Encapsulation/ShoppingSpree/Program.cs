using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var people = new List<Person>();
        var products = new List<Product>();

        var buyers = Console.ReadLine()
            .Trim()
            .Split(new char[] { '=', ';' });

        var market = Console.ReadLine()
            .Trim()
            .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

        try
        {
            for (int i = 0; i < buyers.Length - 1; i += 2)
            {
                var name = buyers[i];
                var money = decimal.Parse(buyers[i + 1]);

                people.Add(new Person(name, money));
            }

            for (int i = 0; i < market.Length - 1; i += 2)
            {
                var name = market[i];
                var cost = decimal.Parse(market[i + 1]);

                products.Add(new Product(name, cost));
            }

            while (true)
            {
                var purchase = Console.ReadLine().Trim().Split();

                if (purchase[0].ToLower() == "end")
                    break;

                var buyer = people.First(x => x.Name.Equals(purchase[0]));
                var product = products.First(x => x.Name.Equals(purchase[1]));

                buyer.Buy(product);
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }

        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}
