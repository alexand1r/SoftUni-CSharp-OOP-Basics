using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            Console.WriteLine(fields.Count());

            var length = double.Parse(Console.ReadLine().Trim());
            var width = double.Parse(Console.ReadLine().Trim());
            var height = double.Parse(Console.ReadLine().Trim());

            try
            {
                Console.WriteLine(new Box(length, width, height));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }