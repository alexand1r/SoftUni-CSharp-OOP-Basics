using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string d1 = Console.ReadLine();
        string d2 = Console.ReadLine();
        DateModifier dm = new DateModifier(d1, d2);
        Console.WriteLine(Math.Abs(dm.Difference()));
    }
}
