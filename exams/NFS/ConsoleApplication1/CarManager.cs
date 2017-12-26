using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class CarManager
{
    public CarManager()
    {
        this.Cars = new Dictionary<int, Car>();
        this.Races = new Dictionary<int, Race>();
        this.Garage = new Garage();
        this.InitiatedRaces = new List<int>();
    }
    public Dictionary<int, Car> Cars { get; set; }
    public Dictionary<int, Race> Races { get; set; }
    public Garage Garage { get; set; }
    public ICollection<int> InitiatedRaces { get; set; }
    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        var carToRegister = CarFactory.CreateCar(type);
        if (carToRegister is PerformanceCar)
        {
            horsepower += (int)(0.5 * horsepower);
            suspension -= (int)(0.25 * suspension);
        }
        carToRegister.Brand = brand;
        carToRegister.Model = model;
        carToRegister.YearOfProduction = yearOfProduction;
        carToRegister.HorsePower = horsepower;
        carToRegister.Acceleration = acceleration;
        carToRegister.Suspension = suspension;
        carToRegister.Durability = durability;

        try
        {
            this.Cars.Add(id, carToRegister);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public string Check(int id)
    {
        var carToCheck = this.Cars.FirstOrDefault(c => c.Key == id).Value;
        return carToCheck.ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        var raceToOpen = RaceFactory.CreateRace(type);
        raceToOpen.Length = length;
        raceToOpen.Route = route;
        raceToOpen.PrizePool = prizePool;
        this.Races.Add(id, raceToOpen);
    }

    public void Participate(int carId, int raceId)
    {
        var carToAdd = this.Cars.FirstOrDefault(c => c.Key == carId).Value;
        if (!this.Garage.ParkedCars.Contains(carToAdd))
        {
            var race = this.Races.FirstOrDefault(r => r.Key == raceId);
            race.Value.Participants.Add(carToAdd);
        }
    }

    public string Start(int id)
    {
        var raceToStart = this.Races.FirstOrDefault(r => r.Key == id).Value;
        if (raceToStart.Participants.Count > 0 && !this.InitiatedRaces.Contains(id))
        {
            this.InitiatedRaces.Add(id);
            return raceToStart.ToString();
        }
        return $"Cannot start the race with zero participants.";
    }

    public void Park(int id)
    {
        var carToPark = this.Cars.FirstOrDefault(c => c.Key == id).Value;
        var isCarInRace = false;
        foreach (var race in this.Races)
        {
            if (isCarInRace)
            {
                break;
            }
            foreach (var racingCar in race.Value.Participants)
            {
                if(carToPark == racingCar)
                {
                    isCarInRace = true;
                    break;
                }
            }
        }

        if(!isCarInRace) this.Garage.ParkedCars.Add(carToPark);
    }
    public void Unpark(int id)
    {
        var carToUnpark = this.Cars.FirstOrDefault(c => c.Key == id).Value;
        this.Garage.ParkedCars.Remove(carToUnpark);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var parkedCar in this.Garage.ParkedCars)
        {
            this.Garage.Modify(parkedCar, tuneIndex, addOn);
        }
    }
}