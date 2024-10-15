using System.Text;
//Task 4: Strings,2d Arrays, user defined functions,Hashmap 
internal class Program
{
    private static void Main(string[] args)
    {
        //9. Parcel Tracking:

        string[,] parcels = new string[,]
        {
             {"T01","Parcel in transit" },
             {"T02","Parcel out for delivery" },
             {"T03","Parcel delivered" },
             {"T04","Parcel in transit" }

        };
        Console.Write("Enter the tracking number: ");
        string inputTrackingNumber = Console.ReadLine();


        // Search for the tracking number in the array
        bool found = false;
        for (int i = 0; i < parcels.GetLength(0); i++)
        {
            if (parcels[i, 0] == inputTrackingNumber)
            {
                // Display the status of the parcel
                Console.WriteLine("Tracking Number: " + parcels[i, 0] + " - Status: " + parcels[i, 1]);
                found = true;
                break;
            }
        }


        // If the tracking number was not found
        if (!found)
        {
            Console.WriteLine("Tracking number not found.");
        }

        Console.WriteLine("_________________________");

        //10. Customer Data Validation

        bool ValidateCustomerData(string data, string details)
        {
            if (details == "name")
            {
                // Name should start with an uppercase letter and the rest should be letters
                if (char.IsUpper(data[0]))
                {
                    for (int i = 1; i < data.Length; i++) // Start loop from index 1
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
                // Validate address (allow letters, spaces, and commas)
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
                // Validate phone number format (XXX-XXX-XXXX)
                if (data.Length == 12 && data[3] == '-' && data[7] == '-')
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (i == 3 || i == 7) continue; // Skip hyphens
                        if (!char.IsDigit(data[i])) // Ensure remaining characters are digits
                            return false;
                    }
                    return true;
                }
                return false;
            }
            else
            {
                // Handle invalid type
                Console.WriteLine("Invalid details type.");
                return false;
            }
        }
        Console.WriteLine("Enter the type of detail to validate (name, address, phone number): ");
        string detailType = Console.ReadLine().ToLower(); // Take input and convert to lowercase

        // Ensure the detailType is either name, address, or phone number
        if (detailType != "name" && detailType != "address" && detailType != "phone number")
        {
            Console.WriteLine("Invalid details type.");
            return;
        }

        Console.WriteLine($"Enter the {detailType} to validate: ");
        string userInput = Console.ReadLine(); // Take input for the detail

        // Validate user input
        bool isValid = ValidateCustomerData(userInput, detailType);

        // Output the result
        if (isValid)
        {
            Console.WriteLine($"{detailType} is valid.");
        }
        else
        {
            Console.WriteLine($"{detailType} is invalid.");
        }

        Console.WriteLine("_________________________");

        //Address Formatting

        Console.WriteLine("Enter the address:");
        string Address = Console.ReadLine();

        Console.WriteLine("Enter the City:");
        string City = Console.ReadLine();

        Console.WriteLine("Enter the State:");
        string State = Console.ReadLine();

        Console.WriteLine("Enter the zip code:");
        string zipCode = Console.ReadLine();

        // Renaming the local variable to avoid conflict with the method name
        string formattedAddress = FormatAddress(Address, City, State, zipCode);
        Console.WriteLine("\nFormatted Address:");
        Console.WriteLine(formattedAddress);

        // Function to format the entire address
        string FormatAddress(string address, string city, string state, string zipCode)
        {
            address = CapitalizeWords(address);
            city = CapitalizeWords(city);
            state = CapitalizeWords(state);
            zipCode = FormatZipCode(zipCode);

            return $"{address}, {city}, {state} {zipCode}";
        }

        // Function to capitalize words
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

        // Function to format the zip code
        string FormatZipCode(string zipCode)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
                return zipCode;

            zipCode = zipCode.Replace("-", "").Trim();
            return zipCode.Length == 9 ? $"{zipCode.Substring(0, 5)}-{zipCode.Substring(5, 4)}" : zipCode;
        }
        Console.WriteLine("_________________________");

        //12 Order Confirmation Email: 

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

        string EmailMessage = GenerateOrderConfirmationMail(Customername, OrderNumber, DeliveryAddress, City, State, ZipCode, ExpectedDeliveryDate);

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
        Console.WriteLine("_________________________");

        //13 Calculate Shipping Cost

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
        Console.WriteLine("_________________________");

        //14 Password Generator

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
        Console.WriteLine("_________________________");

        //15 find similar Address

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
        Console.WriteLine("_________________________");
        Console.ReadKey();


    }
}