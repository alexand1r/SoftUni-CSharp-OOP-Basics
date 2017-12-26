using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    class Program
    {
        static void Main(string[] args)
        {
            var carManager = new CarManager();

            string input;
            while ((input = Console.ReadLine()) != "Cops Are Here")
            {
                var inputInfo = input.Split();

                switch (inputInfo[0])
                {
                    case "register":
                        {
                            carManager.Register(int.Parse(inputInfo[1]), inputInfo[2], inputInfo[3], inputInfo[4], int.Parse(inputInfo[5]), int.Parse(inputInfo[6]), int.Parse(inputInfo[7]), int.Parse(inputInfo[8]), int.Parse(inputInfo[9]));
                        }
                        break;
                    case "check":
                        {
                            Console.WriteLine(carManager.Check(int.Parse(inputInfo[1])));
                        }
                        break;
                    case "open":
                        {
                            carManager.Open(int.Parse(inputInfo[1]), inputInfo[2], int.Parse(inputInfo[3]), inputInfo[4], int.Parse(inputInfo[5]));
                        }
                        break;
                    case "participate":
                        {
                            carManager.Participate(int.Parse(inputInfo[1]), int.Parse(inputInfo[2]));
                        }
                        break;
                    case "start":
                        {
                            Console.WriteLine(carManager.Start(int.Parse(inputInfo[1])));
                        }
                        break;
                    case "unpark":
                        {
                            carManager.Unpark(int.Parse(inputInfo[1]));
                        }
                        break;
                    case "park":
                        {
                            carManager.Park(int.Parse(inputInfo[1]));
                        }
                        break;
                    case "tune":
                        {
                            carManager.Tune(int.Parse(inputInfo[1]), inputInfo[2]);
                        }
                        break;
                }
            }
        }
    }
