using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    class CarFactory
    {
        public static Car CreateCar(string type)
        {
            switch (type.ToLower())
            {
                case "performance":
                    {
                        return new PerformanceCar("","",0,0,0,0,0);
                    }
                case "show":
                    {
                        return new ShowCar("","",0,0,0,0,0);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
