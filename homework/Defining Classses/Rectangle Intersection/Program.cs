using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var line = Console.ReadLine().Split();
        int n = 0;
        int k = 0;
        n = int.Parse(line[0]);
        k = int.Parse(line[1]);
            
        var rects = new Dictionary<string, Rectangle>();
        for (int i = 0; i < n; i++)
        {
            var data = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                rects.Add(data[0], new Rectangle(data[0], double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]), double.Parse(data[4])));
            }
            catch (Exception)
            {
            }
        }
        for (int i = 0; i < k; i++)
        {

            var pair = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (rects[pair[0]].HasIntersect(rects[pair[1]]))
            {
                Console.WriteLine("true");
            }
            else Console.WriteLine("false");
        }
     }
}