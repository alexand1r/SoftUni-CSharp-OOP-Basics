using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();

            string name = input[0];
            decimal salary = decimal.Parse(input[1]);
            string position = input[2];
            string department = input[3];
            string email = "n/a";
            int age = -1;

            for (int j = 4; j < input.Length; j++)
            {
                if (input[j].Contains("@"))
                {
                    email = input[j];
                }
                else
                {
                    try
                    {
                        age = int.Parse(input[j]);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            new Employee(name, position, department, salary, age, email);

        }

        Employee.Print();
    }
}

