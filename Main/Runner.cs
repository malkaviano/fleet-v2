using System;
using System.Linq;
using Business;

namespace Main
{
    public class Runner
    {
        private readonly IVehicleRepo repo;

        public Runner(IVehicleRepo repo)
        {
            this.repo = repo;
        }

        public string Menu()
        {
            Console.WriteLine("");
            Console.WriteLine("*************************************");
            Console.WriteLine("Fleet CRUD");
            Console.WriteLine("Type the option desired:");
            Console.WriteLine("1 - Find a vehicle by chassis");
            Console.WriteLine("2 - Add new vehicle to the fleet");
            Console.WriteLine("3 - Update vehicle color");
            Console.WriteLine("4 - Remove a vehicle from the fleet");
            Console.WriteLine("5 - List all fleet vehicles");
            Console.WriteLine("X - Leave");

            return Console.ReadLine();
        }

        public void Execute()
        {
            do
            {
                var op = this.Menu();

                switch (op.ToUpper())
                {
                    case "1":
                        {
                            this.FindVehicle();

                            break;
                        }
                    case "2":
                        {
                            var vehicle = this.AskForVehicle();

                            if (vehicle != null)
                            {
                                this.repo.Add(vehicle);
                            }

                            break;
                        }
                    case "3":
                        {
                            var vehicle = this.AskNewColor();

                            if (vehicle != null)
                            {
                                this.repo.Add(vehicle);
                            }

                            break;
                        }
                    case "4":
                        {
                            this.RemoveVehicle();

                            break;
                        }
                    case "5":
                        {
                            this.PrintAll();

                            break;
                        }
                    case "X":
                        {
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Option invalid");
                            break;
                        }
                }
            } while (true);
        }

        private Vehicle GetVehicle(string chassis) => this.repo.FindByChassis(chassis);

        private void FindVehicle()
        {
            Console.WriteLine("Inform chassis:");
            var chassis = Console.ReadLine();

            var vehicle = this.GetVehicle(chassis);

            if (vehicle == null)
            {
                Console.WriteLine("Vehicle not found");

                return;
            }

            Console.WriteLine(vehicle);
        }

        private string AskForChassis()
        {
            Console.WriteLine("Inform chassis:");
            return Console.ReadLine();
        }

        private string AskForColor()
        {
            Console.WriteLine("Inform color:");
            return Console.ReadLine();
        }

        private Vehicle AskForVehicle()
        {
            var chassis = this.AskForChassis();

            if (this.GetVehicle(chassis) != null)
            {
                Console.WriteLine("Chassis already registered in Fleet");

                return null;
            }

            var color = this.AskForColor();

            Console.WriteLine("Type 1 for Truck and 2 for Bus:");

            VehicleCategory category;

            try
            {
                category = (VehicleCategory)Enum.Parse(
                   typeof(VehicleCategory),
                   Console.ReadLine()
               );
            }
            catch (Exception)
            {
                Console.WriteLine("Error(s) occured!");
                Console.WriteLine("You did not typed 1 or 2 for category");

                return null;
            }

            try
            {
                return VehicleFactory.Create(chassis, color, category);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error(s) occured!");
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        private Vehicle AskNewColor()
        {
            var chassis = this.AskForChassis();

            var vehicle = this.GetVehicle(chassis);

            if (vehicle == null)
            {
                Console.WriteLine("Chassis not registered in Fleet");

                return null;
            }

            var color = this.AskForColor();

            vehicle.Color = color;

            return vehicle;
        }

        private void RemoveVehicle()
        {
            var chassis = this.AskForChassis();

            var result = this.repo.Remove(chassis);

            if (result == null)
            {
                Console.WriteLine("Chassis not registered in Fleet");

                return;
            }

            Console.WriteLine("Vehicle removed from Fleet");
        }

        private void PrintAll()
        {
            this.repo.List().ToList().ForEach(v => Console.WriteLine(v));
        }
    }
}