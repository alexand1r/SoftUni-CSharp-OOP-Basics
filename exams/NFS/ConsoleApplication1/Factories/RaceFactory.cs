using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    class RaceFactory
    {
        public static Race CreateRace(string type)
        {
            switch (type.ToLower())
            {
                case "casual":
                    {
                        return new CasualRace(0,"",0,new List<Car>());
                    }
                case "drag":
                    {
                        return new DragRace(0, "", 0, new List<Car>());
                    }
                case "drift":
                    {
                        return new DriftRace(0, "", 0, new List<Car>());
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
