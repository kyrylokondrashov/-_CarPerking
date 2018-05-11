using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA_homework
{
    class Parking
    {

        public List<Car> cars { get; private set; }
        public List<Transaction> transactions { get; private set; }

        private static readonly Lazy<Parking> myParking = new Lazy<Parking>(() => new Parking());

        public static Parking Source { get { return myParking.Value; } }

        private Parking()
        {
            cars = new List<Car>();
            transactions = new List<Transaction>();
        }

        public float parkingIncome { get; private set; }

        public void addCar(uint id, carType type, float balance)
        {
            if(Settings.myParking.cars.Count >= Settings.parkingPlaces)
            {
                throw new Exception("There are no free spaces.");
            }
            else
            {
                var carInParking = cars.FirstOrDefault<Car>(c => c.currentID == id);
                if (carInParking != null)
                {
                    throw new Exception("Car has been already added.");
                }
                else
                {
                    cars.Add(new Car(id,type,balance));
                }
            }
            
        }
        public void removeCar(uint id)
        {
            Car someCar = cars.First<Car>(c => c.currentID == id);
            if (someCar.currentBalance > 0)
                {
                    cars.Remove(someCar);
                }
                else
                {
                    throw new Exception("Can't remove car with balance less than 0. Please add money.");
                }
        }
        public void addBalance(uint id, float moneyOnBalance)
        {

            Car someCar = cars.First<Car>(c => c.currentID == id);
            someCar.addToBalance(moneyOnBalance);  
        }

        public float showCarBalance(uint id)
        {

            Car someCar = cars.First<Car>(c => c.currentID == id);
            return someCar.currentBalance;
        }
        public float getCarBalance(uint id)
        {
            Car someCar = cars.First<Car>(c => c.currentID == id);
            return someCar.currentBalance;
        }

        public float addIncome(float income)
        {
            parkingIncome += income;
            return parkingIncome;
        }
    }
}
