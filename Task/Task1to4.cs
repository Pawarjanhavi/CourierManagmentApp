using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Task
{   //Task1
    // 1. Check Order Status
    public static void CheckOrderStatus()
    {
        Console.WriteLine("Enter the status of the order (Processing, Delivered, Cancelled):");
        string status = Console.ReadLine();

        if (status == "Delivered")
        {
            Console.WriteLine("Order is delivered");
        }
        else if (status == "Processing")
        {
            Console.WriteLine("Order is Processing");
        }
        else if (status == "Cancelled")
        {
            Console.WriteLine("Order is Cancelled");
        }
        else
        {
            Console.WriteLine("Entered status is not in the list");
        }
    }

    // 2. Parcel Weight Categorization
    public static void ParcelWeightCategorization()
    {
        Console.WriteLine("Enter the weight of the parcel in KGs:");
        if (double.TryParse(Console.ReadLine(), out double weight))
        {
            if (weight <= 1.0)
            {
                Console.WriteLine("Parcel is less than or equal to 1 KG, categorized as Light.");
            }
            else if (weight > 1.0 && weight < 5.0)
            {
                Console.WriteLine("Parcel is less than 5 KG but greater than 1 KG, categorized as Medium.");
            }
            else if (weight >= 5)
            {
                Console.WriteLine("Parcel is greater than or equal to 5 KG, categorized as Heavy.");
            }
        }
        else
        {
            Console.WriteLine("Invalid weight entered. Please enter a numeric value.");
        }
    }

    // 3. User Authentication
    public static void UserAuthentication()
    {
        Console.WriteLine("Enter your role (Employee - E or Customer - C):");
        char role = Convert.ToChar(Console.ReadLine().ToUpper());

        var employeeCredentials = new (string username, string password)[] { ("vijay", "pass") };
        var customerCredentials = new (string username, string password)[] { ("jai", "pass") };

        Console.WriteLine("Enter your username:");
        string username = Console.ReadLine();
        Console.WriteLine("Enter your password:");
        string password = Console.ReadLine();

        if (role == 'E')
        {
            if (username == employeeCredentials[0].username && password == employeeCredentials[0].password)
            {
                Console.WriteLine($"\nWelcome {username}\nLogged in Successfully!");
            }
            else
            {
                Console.WriteLine("Invalid Credentials!");
            }
        }
        else if (role == 'C')
        {
            if (username == customerCredentials[0].username && password == customerCredentials[0].password)
            {
                Console.WriteLine($"\nWelcome {username}\nLogged in Successfully!");
            }
            else
            {
                Console.WriteLine("Invalid Credentials!");
            }
        }
        else
        {
            Console.WriteLine("Invalid Role Entry");
        }
    }
    //task 1:4
    public class Courier
    {
        public int CourierID { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public decimal Weight { get; set; }
        public string Status { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal LoadCapacity { get; set; } // Maximum weight the courier can carry
        public bool IsAvailable { get; set; } = true; // Courier availability
        public string CurrentLocation { get; set; }
        public Courier(int id, string senderName, string senderAddress, string receiverName, string receiverAddress, decimal weight, string status, string trackingNumber, DateTime deliveryDate, decimal loadCapacity)
        {
            CourierID = id;
            SenderName = senderName;
            SenderAddress = senderAddress;
            ReceiverName = receiverName;
            ReceiverAddress = receiverAddress;
            Weight = weight;
            Status = status;
            TrackingNumber = trackingNumber;
            DeliveryDate = deliveryDate;
            LoadCapacity = loadCapacity;
            CurrentLocation = senderAddress;

        }
    }
    public class Shipment
    {
        public int ShipmentID { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public string Destination { get; set; }

        public Shipment(int shipmentID, string description, decimal weight, string destination)
        {
            ShipmentID = shipmentID;
            Description = description;
            Weight = weight;
            Destination = destination;
        }
    }

    public class CourierAssignment
    {
        public static void AssignCouriersToShipments(List<Courier> couriers, List<Shipment> shipments)
        {
            foreach (var shipment in shipments)
            {
                foreach (var courier in couriers)
                {
                    // Check if the courier can carry the shipment weight and is available
                    if (courier.IsAvailable && courier.LoadCapacity >= shipment.Weight)
                    {
                        
                        Console.WriteLine($"Assigned Courier {courier.SenderName} (ID: {courier.CourierID}) to Shipment {shipment.Description} (ID: {shipment.ShipmentID})");
                        courier.IsAvailable = false;
                        shipment.Weight = 0; 
                        break; 
                    }
                }
            }
        }
    }

    //Task2
    // 1.Display Customer Orders
    public static void DisplayCustomerOrders()
    {
        List<(int orderid, int customerid, string orderdetails)> orders = new List<(int, int, string)>
        {
            (1, 101, "Courier from City A to City B"),
            (2, 102, "Courier from City C to City D"),
            (3, 101, "Courier from City E to City F"),
            (4, 103, "Courier from City G to City H"),
            (5, 101, "Courier from City I to City J")
        };

        Console.WriteLine("Enter CustomerID to display their orders:");
        int customerid = int.Parse(Console.ReadLine());

        Console.WriteLine($"Orders for CustomerID {customerid}: ");
        int count = 0;
        foreach (var order in orders)
        {
            if (order.customerid == customerid)
            {
                Console.WriteLine($"Order ID: {order.orderid}, Details: {order.orderdetails}");
                count++;
            }
        }

        if (count == 0)
        {
            Console.WriteLine("No orders found for this customer.");
        }
    }
    //Implement a while loop to track the real-time location of a courier until it reaches its destination
    private static List<Courier> courierList = new List<Courier>
        {
            new Courier(1, "Alice", "123 Elm St", "Bob", "456 Oak St", 5.0m, "In Transit", "TRACK123", DateTime.Now.AddDays(3), 10.0m),
            new Courier(2, "Charlie", "789 Pine St", "Diana", "101 Maple St", 2.5m, "Delivered", "TRACK456", DateTime.Now.AddDays(2), 8.0m),
           
        };
    public static void TrackCourier(int courierID)
    {


        // Find the courier
        var courier = courierList.FirstOrDefault(c => c.CourierID == courierID);



        if (courier == null)
        {
            Console.WriteLine("Courier not found.");
            return;
        }

        Console.WriteLine($"Tracking Courier {courier.SenderName}...");

        
        while (courier.CurrentLocation != courier.ReceiverAddress)
        {
           
            if (courier.CurrentLocation == courier.SenderAddress)
            {
                Console.WriteLine($"Courier {courier.SenderName} is en route to {courier.ReceiverAddress}.");
                courier.CurrentLocation = "In Transit"; 
            }
            else if (courier.CurrentLocation == "In Transit")
            {
               
                courier.CurrentLocation = courier.ReceiverAddress;
                Console.WriteLine($"Courier {courier.SenderName} has reached the destination: {courier.ReceiverAddress}.");
                break; 
            }

         
            Thread.Sleep(2000); 
        }
    }


    //Task3
    // 1. Track Courier Location
    public static void TrackCourierLocation()
    {
        Console.WriteLine("Tracking History:");

        string[] trackingHistory = new string[3];
        trackingHistory[0] = "Sender Location , 2024-10-01 10:00:00";
        trackingHistory[1] = "In Transit , 2024-10-05 13:15:00";
        trackingHistory[2] = "Receiver's Location , 2024-10-15 12:45:00";

        foreach (var update in trackingHistory)
        {
            Console.WriteLine(update);
        }
    }

    // 2. Find Nearest Available Courier
    public static void FindNearestCourier()
    {
        var couriers = new (string Name, double Latitude, double Longitude, bool IsAvailable)[]
        {
            ("Courier A", 37.7749, -122.4194, true),
            ("Courier B", 40.7128, -74.0060, false),
            ("Courier C", 34.0522, -118.2437, true)
        };

        double userLat = 36.7783;
        double userLon = -119.4179;

        var nearest = FindNearestCourier(couriers, userLat, userLon);

        if (nearest != null)
            Console.WriteLine("Nearest available courier: " + nearest.Value.Name);
        else
            Console.WriteLine("No available couriers.");
    }

    private static (string Name, double Latitude, double Longitude, bool IsAvailable)? FindNearestCourier(
        (string Name, double Latitude, double Longitude, bool IsAvailable)[] couriers,
        double userLat, double userLon)
    {
        (string Name, double Latitude, double Longitude, bool IsAvailable)? nearest = null;
        double minDistance = double.MaxValue;

        foreach (var courier in couriers)
        {
            if (!courier.IsAvailable)
                continue;

            double distance = Math.Sqrt(Math.Pow(courier.Latitude - userLat, 2) + Math.Pow(courier.Longitude - userLon, 2));

            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = courier;
            }
        }

        return nearest;
    }

    //Task 4 : : Strings,2d Arrays, user defined functions,Hashmap
    //Parcel Tracking
    public static void ParcelTracking()
    {
        string[,] parcels = new string[,]
        {
            {"T01","Parcel in transit" },
            {"T02","Parcel out for delivery" },
            {"T03","Parcel delivered" },
            {"T04","Parcel in transit" }
        };

        Console.Write("Enter the tracking number: ");
        string inputTrackingNumber = Console.ReadLine();

        bool found = false;
        for (int i = 0; i < parcels.GetLength(0); i++)
        {
            if (parcels[i, 0] == inputTrackingNumber)
            {
                Console.WriteLine("Tracking Number: " + parcels[i, 0] + " - Status: " + parcels[i, 1]);
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Tracking number not found.");
        }
    }

    // Task 4: Customer Data Validation
    public static void CustomerDataValidation()
    {
        bool ValidateCustomerData(string data, string details)
        {
            if (details == "name")
            {
                if (char.IsUpper(data[0]))
                {
                    for (int i = 1; i < data.Length; i++)
                    {
                        if (!char.IsLetter(data[i]) || char.IsUpper(data[i]))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
            else if (details == "address")
            {
                foreach (char c in data)
                {
                    if (!char.IsLetter(c) && c != ' ' && c != ',')
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (details == "phone number")
            {
                if (data.Length == 12 && data[3] == '-' && data[7] == '-')
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (i == 3 || i == 7) continue;
                        if (!char.IsDigit(data[i]))
                            return false;
                    }
                    return true;
                }
                return false;
            }
            else
            {
                Console.WriteLine("Invalid details type.");
                return false;
            }
        }

        Console.WriteLine("Enter the type of detail to validate (name, address, phone number): ");
        string detailType = Console.ReadLine().ToLower();

        if (detailType != "name" && detailType != "address" && detailType != "phone number")
        {
            Console.WriteLine("Invalid details type.");
            return;
        }

        Console.WriteLine($"Enter the {detailType} to validate: ");
        string userInput = Console.ReadLine();

        bool isValid = ValidateCustomerData(userInput, detailType);

        if (isValid)
        {
            Console.WriteLine($"{detailType} is valid.");
        }
        else
        {
            Console.WriteLine($"{detailType} is invalid.");
        }
    }

    // Task 5: Address Formatting
    public static void AddressFormatting()
    {
        Console.WriteLine("Enter the address:");
        string address = Console.ReadLine();

        Console.WriteLine("Enter the City:");
        string city = Console.ReadLine();

        Console.WriteLine("Enter the State:");
        string state = Console.ReadLine();

        Console.WriteLine("Enter the zip code:");
        string zipCode = Console.ReadLine();

        string formattedAddress = FormatAddress(address, city, state, zipCode);
        Console.WriteLine("\nFormatted Address:");
        Console.WriteLine(formattedAddress);

        string FormatAddress(string addr, string c, string s, string zip)
        {
            addr = CapitalizeWords(addr);
            c = CapitalizeWords(c);
            s = CapitalizeWords(s);
            zip = FormatZipCode(zip);

            return $"{addr}, {c}, {s} {zip}";
        }

        string CapitalizeWords(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            string[] words = input.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }

            return string.Join(" ", words);
        }

        string FormatZipCode(string zipCode)
        {
            zipCode = zipCode.Replace("-", "").Trim();
            return zipCode.Length == 9 ? $"{zipCode.Substring(0, 5)}-{zipCode.Substring(5, 4)}" : zipCode;
        }
    }

    //Order Confirmation Email
    public static void OrderConfirmationEmail()
    {
        Console.WriteLine("Enter Customer Name :");
        string Customername = Console.ReadLine();

        Console.WriteLine("Enter Order Number :");
        string OrderNumber = Console.ReadLine();

        Console.WriteLine("Enter Delivery Address :");
        string DeliveryAddress = Console.ReadLine();

        Console.WriteLine("Enter City :");
        string DeliveryCity = Console.ReadLine();

        Console.WriteLine("Enter State :");
        string DeliveryState = Console.ReadLine();

        Console.WriteLine("Enter Zip Code :");
        string ZipCode = Console.ReadLine();

        Console.WriteLine("Enter Expected Delivery Date(MM/DD/YYYY) :");
        string ExpectedDeliveryDate = Console.ReadLine();

        string EmailMessage = GenerateOrderConfirmationMail(Customername, OrderNumber, DeliveryAddress,DeliveryCity,DeliveryState, ZipCode, ExpectedDeliveryDate);

        Console.WriteLine("\nOrder Confirmation Email :");
        Console.WriteLine(EmailMessage);


        String GenerateOrderConfirmationMail(string Customername, string OrderNumber, string DeliveryAddress, string City, string State, string ZipCode, string ExpectedDeliveryDate)
        {
            string Email = $"Dear {Customername},\n\n" +
                       $"Thank you for ordering from us!\n\n" +
                       $"Order Number: {OrderNumber}\n" +
                       $"Delivery Address: {DeliveryAddress}, {City}, {State} {ZipCode}\n" +
                       $"Expected Delivery Date: {ExpectedDeliveryDate}\n\n" +
                       $"Looking forward to delivering your order.";
            return Email;

        }
    }

    //Calculate Shipping Cost
    public static void CalculateShippingCost()
    {
        // Prompt for source address
        Console.WriteLine("Enter the Sender's Address:");
        string sourceAddress = Console.ReadLine();

        // Prompt for destination address
        Console.WriteLine("Enter the Receiver's Address:");
        string destinationAddress = Console.ReadLine();

        // Prompt for distance
        Console.WriteLine("Enter the Distance (in kilometers):");
        string distanceInput = Console.ReadLine();
        double distance;

        // Try to parse the distance input
        if (!double.TryParse(distanceInput, out distance) || distance <= 0)
        {
            Console.WriteLine("Invalid distance entered. Please enter a positive number.");
            return;
        }

        // Prompt for weight of the parcel
        Console.WriteLine("Enter the weight of the parcel:");
        string weightInput = Console.ReadLine();
        double weight;

        // Try to parse the weight input
        if (!double.TryParse(weightInput, out weight) || weight <= 0)
        {
            Console.WriteLine("Invalid weight entered. Please enter a positive number.");
            return;
        }

        //13 Calculate shipping cost
        double shippingCost = CalculateShippingCost(distance, weight);
        Console.WriteLine($"The shipping cost from {sourceAddress} to {destinationAddress} is: Rs{shippingCost:F2}");


        // Function to calculate shipping cost
        double CalculateShippingCost(double distance, double weight)
        {
            // Assume a base rate and a rate per kilometer and per kg
            const double baseRate = 50.00; // Base shipping cost
            const double ratePerKm = 10.00; // Cost per kilometer
            const double ratePerKg = 15.00; // Cost per kilogram

            // Calculate total shipping cost
            double totalCost = baseRate + (ratePerKm * distance) + (ratePerKg * weight);
            return totalCost;
        }
    }
    //Password Generator
    public static void PasswordGeneration()
    {
        Console.WriteLine("Enter the desired password length (minimum 8 characters):");
        if (int.TryParse(Console.ReadLine(), out int passwordLength) && passwordLength >= 8)
        {
            string generatedPassword = GenerateSecurePassword(passwordLength);
            Console.WriteLine($"Generated secure password: {generatedPassword}");
        }
        else
        {
            Console.WriteLine("Please enter a valid password length of at least 8 characters.");
        }

        string GenerateSecurePassword(int length)
        {
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string numbers = "0123456789";
            const string specialCharacters = "!@#$%^&*()-_=+[]{}|;:,.<>?";

            // Ensure password contains at least one character from each category
            Random random = new Random();
            StringBuilder password = new StringBuilder();

            password.Append(uppercase[random.Next(uppercase.Length)]);
            password.Append(lowercase[random.Next(lowercase.Length)]);
            password.Append(numbers[random.Next(numbers.Length)]);
            password.Append(specialCharacters[random.Next(specialCharacters.Length)]);

            // Fill the rest of the password length with a random mix
            string allCharacters = uppercase + lowercase + numbers + specialCharacters;

            for (int i = 4; i < length; i++)
            {
                password.Append(allCharacters[random.Next(allCharacters.Length)]);
            }

            return password.ToString();
        }
    }

    //Find Similar Address
    public static void FindSimilarAddress()
    {
        List<string> addresses = new List<string>
        {
            "Kalika Nagar, Kopargaon",
            "Kalika Nagar, Kopargaon",
            "Pimpri Chinchwad, Pune",
            "Pimpri Chinchwad, Pune, Maharashtra"

        };

        var similarAddresses = FindSimilarAddresses(addresses);
        foreach (var pair in similarAddresses)
        {
            Console.WriteLine($"Similar Addresses: \n1. {pair.Item1} \n2. {pair.Item2}\n");
        }

        List<Tuple<string, string>> FindSimilarAddresses(List<string> addresses)
        {
            var similarPairs = new List<Tuple<string, string>>();

            for (int i = 0; i < addresses.Count; i++)
            {
                for (int j = i + 1; j < addresses.Count; j++)
                {
                    // Normalize both addresses: trim spaces and convert to lowercase
                    string normalizedAddress1 = addresses[i].Trim().ToLower();
                    string normalizedAddress2 = addresses[j].Trim().ToLower();

                    // Compare normalized addresses
                    if (string.Equals(normalizedAddress1, normalizedAddress2))
                    {
                        similarPairs.Add(new Tuple<string, string>(addresses[i], addresses[j]));
                    }
                }
            }

            return similarPairs;

        }
    }

}



