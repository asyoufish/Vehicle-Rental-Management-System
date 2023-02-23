namespace A1TszFungChan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Populate the vehicles List
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(new Car(1, "Honda Civic", 69.9, Car.Category.Sedan, Car.Type.Standard, false));
            vehicles.Add(new Car(2, "Toyota Corolla", 69.9, Car.Category.Sedan, Car.Type.Standard, false));
            vehicles.Add(new Car(3, "Ford Explorer", 99.9, Car.Category.SUV, Car.Type.Standard, false));
            vehicles.Add(new Car(4, "Nissan Versa", 49.9, Car.Category.Hatchback, Car.Type.Standard, false));
            vehicles.Add(new Car(5, "Hyndai Tucson", 89.9, Car.Category.SUV, Car.Type.Standard, false));
            vehicles.Add(new Car(6, "Lamborghini Aventador", 189.9, Car.Category.Sports, Car.Type.Exotic, false));
            vehicles.Add(new Car(7, "Ferrari 488 GTB", 179.9, Car.Category.Sports, Car.Type.Exotic, false));
            vehicles.Add(new Car(8, "McLaren P1", 199.9, Car.Category.Sports, Car.Type.Exotic, false));
            vehicles.Add(new Motorcycle(9, "Suzuki Boulevard M109R", 49.9, Motorcycle.Category.Cruiser, Motorcycle.Type.Bike, false));
            vehicles.Add(new Motorcycle(10, "Harley-Davidson Street Glide", 79.9, Motorcycle.Category.Cruiser, Motorcycle.Type.Bike, false));
            vehicles.Add(new Motorcycle(11, "Honda CRF125", 39.9, Motorcycle.Category.Dirt, Motorcycle.Type.Bike, false));
            vehicles.Add(new Motorcycle(12, "Ducati Monster", 69.9, Motorcycle.Category.Sports, Motorcycle.Type.Bike, false));
            vehicles.Add(new Motorcycle(13, "Can-Am Spyder", 59.9, Motorcycle.Category.Cruiser, Motorcycle.Type.Trike, false));
            vehicles.Add(new Motorcycle(14, "Plaris Slingshot", 69.9, Motorcycle.Category.Cruiser, Motorcycle.Type.Trike, false));

            // Create the standard Menu
            string switchLine = "1 - View all vehicles\n2 - View available vehicles\n3 - View reserved vehicles\n4 - Reserve a vehicle\n5 - Cancel reservation\n6 - Exit";

            // Create LINQ which get all vehicles
            var vehiclesQuery = from vehicle in vehicles
                                select vehicle;

            int input = 0;

            while (input != 6)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine(switchLine);
                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1: // View all vehicles
                        Console.WriteLine($"{"Id",10} {"Name",-30} {"Rental Price",13} {"Category",-10} {"Type",-10} {"Available",-10}");
                        Console.WriteLine("\n");

                        // LINQ to get all vehicles
                        vehiclesQuery = from vehicle in vehicles
                                        select vehicle;
                        foreach (Vehicle vehicle in vehiclesQuery)
                            Console.WriteLine(vehicle);
                        break;

                    case 2: // View available vehicles
                        Console.WriteLine("Available Vehicles:\n");
                        Console.WriteLine($"{"Id",10} {"Name",-30} {"Rental Price",13} {"Category",-10} {"Type",-10}");

                        // LINQ to get only the available vehicles
                        vehiclesQuery = from vehicle in vehicles
                                        where vehicle.IsReserved == false
                                        select vehicle;
                        foreach (Vehicle vehicle in vehiclesQuery)
                            Console.WriteLine(vehicle.DisplayWOAvailable());
                        break;

                    case 3: // View reserved vehicles
                        vehiclesQuery = from vehicle in vehicles
                                        where vehicle.IsReserved == true
                                        select vehicle;
                        if (vehiclesQuery.Count() == 0)
                        {
                            Console.WriteLine("No records found.");
                        }
                        else
                        {
                            Console.WriteLine($"{"Id",10} {"Name",-30} {"Rental Price",13} {"Category",-10} {"Type",-10}");
                            foreach (Vehicle vehicle in vehiclesQuery)
                                Console.WriteLine(vehicle.DisplayWOAvailable());
                        }
                        break;

                    case 4: // Reserve a vehicle
                        Console.WriteLine("Available Vehicles:\n");
                        Console.WriteLine($"{"Id",10} {"Name",-30} {"Rental Price",13} {"Category",-10} {"Type",-10}");

                        // LINQ to get only the available vehicles
                        vehiclesQuery = from vehicle in vehicles
                                        where vehicle.IsReserved == false
                                        select vehicle;
                        foreach (Vehicle vehicle in vehiclesQuery)
                            Console.WriteLine(vehicle.DisplayWOAvailable());

                        // Read the ID to be reserved
                        Console.Write("Enter vehicle ID to reserve: ");
                        int reserveID = int.Parse(Console.ReadLine());

                        vehicles[reserveID - 1].ReserveVehicle();

                        vehiclesQuery = from vehicle in vehicles
                                        where vehicle.ID == reserveID
                                        select vehicle;

                        if (vehicles[reserveID - 1].IsReserved == true)
                        {
                            Console.WriteLine("Vehicle Reservation Successful:\n");
                        }
                        else
                        {
                            Console.WriteLine("Vehicle Reservation Unsuccessful:");
                            break;
                        }
                        Console.WriteLine($"{"Id",10} {"Name",-30} {"Rental Price",13} {"Category",-10} {"Type",-10}");
                        foreach (Vehicle vehicle in vehiclesQuery)
                            Console.WriteLine(vehicle.DisplayWOAvailable());


                        break;

                    case 5: // Cancel reservation
                        vehiclesQuery = from vehicle in vehicles
                                        where vehicle.IsReserved == true
                                        select vehicle;
                        if (vehiclesQuery.Count() == 0)
                        {
                            Console.WriteLine("No records found.");
                        }
                        else
                        {
                            Console.WriteLine($"{"Id",10} {"Name",-30} {"Rental Price",13} {"Category",-10} {"Type",-10}");
                            foreach (Vehicle vehicle in vehiclesQuery)
                                Console.WriteLine(vehicle.DisplayWOAvailable());
                        }

                        // Read the ID to cancel reserve
                        Console.Write("Enter vehicle ID to cancel reservation: ");
                        int cancelID = int.Parse(Console.ReadLine());

                        vehicles[cancelID - 1].CancelReserve();

                        if (vehicles[cancelID - 1].IsReserved == true)
                        {
                            Console.WriteLine("Vehicle Reservation Successfully Cancelled:\n");
                        }
                        else
                        {
                            Console.WriteLine("Vehicle Reservation Cancellation Unsuccessful:");
                            break;
                        }

                        vehiclesQuery = from vehicle in vehicles
                                        where vehicle.ID == cancelID
                                        select vehicle;

                        Console.WriteLine($"{"Id",10} {"Name",-30} {"Rental Price",13} {"Category",-10} {"Type",-10}");
                        foreach (Vehicle vehicle in vehiclesQuery)
                            Console.WriteLine(vehicle.DisplayWOAvailable());

                        break;

                    case 6:
                        Console.WriteLine(6);
                        break;
                    default:
                        Console.WriteLine("Please input number 1 - 6");
                        break;
                }
                PrintContinue();
                Console.ReadLine();
            }

        }

        public static void PrintContinue()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Press any key to continue...");
        }

    }
}

