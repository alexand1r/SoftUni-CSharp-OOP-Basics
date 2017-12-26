using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    public class Garage
    {
        public Garage()
        {
            this.ParkedCars = new List<Car>();
        }
        public ICollection<Car> ParkedCars { get; set; }

        public void Modify(Car car, int tuneIndex, string addOn)
        {
            car.HorsePower += tuneIndex;
            car.Suspension += tuneIndex / 2;
            var testCar = car as PerformanceCar;

            if (testCar != null)
            {
                testCar.AddOns.Add(addOn);
            }
            else
            {
                var test = ((ShowCar)car);
                test.Stars += tuneIndex;
            }
        }
    }
