using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA_homework
{
    class Menu
    {
        public static bool Active { get; private set; } = true;
        public static void ChooseCommande()
        {
            Console.WriteLine("Commands: ");
            Console.WriteLine("1. Add a car");
            Console.WriteLine("2. Show a balance of the car");
            Console.WriteLine("3. Put money on the balance");
            Console.WriteLine("4. Remove");
            Console.WriteLine("5. Show free spaces");
            Console.WriteLine("6. Show amount of car ");
            Console.WriteLine("7. Show income of the parking");
            Console.WriteLine("8. Show income of the parking per last minute");
            Console.WriteLine("9. Show Transaction.log");
            Console.WriteLine("10. Close");
            int commande = Int32.Parse(Console.ReadLine());
            switch (commande)
            {
                case 1:
                    addCar();
                    break;
                case 2:
                    showCarBalance();
                    break;
                case 3:
                    addBalance();
                    break;
                case 4:
                    removeCar();
                    break;
                case 5:
                    showFreeSpaces();
                    break;
                case 6:
                    showCarAmounts();
                    break;
                case 7:
                    showmyParkingBalance();
                    break;
                case 8:
                    showEarningsPerMinute();
                    break;
                case 9:
                    showTrasactionsFile();
                    break;
                case 10:
                    stopProgramme();
                    break;
                default:
                    throw new Exception("Unknown command");

            }
        }
        private static void stopProgramme()
        {
           Active = false;
        }

        private static void addCar()
        {
            Console.WriteLine("Input id: ");
            uint id = UInt32.Parse(Console.ReadLine());
            Console.WriteLine("Input type (Passenger/Truck/Bus/Motorcycle): ");
            string type = Console.ReadLine();
            carType cType;

            switch (type.ToLower())
            {
                case "passenger":
                    cType = carType.passanger;
                    break;
                case "truck":
                    cType = carType.truck;
                    break;
                case "bus":
                    cType = carType.bus;
                    break;
                case "motorcycle":
                    cType = carType.motorcycle;
                    break;
                default:
                    throw new Exception("We cant't add this type of car.");
            }
            Console.WriteLine("Enter car balance: ");
            float balance = float.Parse(Console.ReadLine());
            Settings.myParking.addCar(id, cType, balance);
            Console.WriteLine("Car has been successfully added");
        }

        private static void removeCar()
        {
            Console.WriteLine("Input id: ");
            uint id = UInt32.Parse(Console.ReadLine());
            Settings.myParking.removeCar(id);
            Console.WriteLine("Car has been removed");

        }

        private static void addBalance()
        {
            Console.WriteLine("Input id: ");
            uint id = UInt32.Parse(Console.ReadLine());
            Console.WriteLine("How much money do you want to put on balance : ");
            float amount = float.Parse(Console.ReadLine());
            Settings.myParking.addBalance(id, amount);
            Console.WriteLine("Success");

        }

        private static void showCarAmounts()
        {
            Console.WriteLine("There are {0} car on the parking right now", Settings.myParking.cars.Count);
        }

        private static void showmyParkingBalance()
        {
            Console.WriteLine("Parking Income {0}", Settings.myParking.parkingIncome);
        }
      
        private static void showFreeSpaces()
        {
            Console.WriteLine("There are {0} free spaces", Settings.parkingPlaces - Settings.myParking.cars.Count);
        }

        private static void showCarBalance()
        {
            Console.WriteLine("Input id: ");
            uint id = UInt32.Parse(Console.ReadLine());
            Console.WriteLine("Balance of the chosen car: {0}", Settings.myParking.showCarBalance(id));
        }

        private static void showEarningsPerMinute()
        {
            var lastTransaction = (from t in Settings.myParking.transactions where (DateTime.Now - t.tranactionDate) < new TimeSpan(0, 1, 0) select t.moneyRemobeBalance).Sum();
            Console.WriteLine("Income per last minute: {0}", lastTransaction);
        }


        private static void showTrasactionsFile()
        {
            Console.WriteLine("Transaction.log: ");
            using (FileStream sr = File.OpenRead("Transaction.log"))
            {
                byte[] array = new byte[sr.Length];
                sr.Read(array, 0, array.Length);
                string text = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine(text);
            }
        }
    }


       
}

