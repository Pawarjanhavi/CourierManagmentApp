//--Task 1: Control Flow Statements--


//1. Write a program that checks whether a given order is delivered or not based on its status (e.g.,
//"Processing," "Delivered," "Cancelled"). Use if-else statements for this. 

using System;

public class Task1
{
    private static void Main(string[] args)
    {
        // Order Status Check
        Console.WriteLine("Enter the status of the order from the below: \r\n\"Processing\" \"Delivered\" \"Cancelled\" ");
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
            Console.WriteLine("Entered status is not in list");
        }
        Console.WriteLine("------------------------------------------------");

        // Parcel Weight Categorization
        Console.WriteLine("Enter the weight of the parcel in KGs:");
        if (double.TryParse(Console.ReadLine(), out double weight))
        {
            if (weight <= 1.0)
            {
                Console.WriteLine("Parcel is less than or equal to 1 KG, so categorized into Light!");
            }
            else if (weight > 1.0 && weight < 5.0)
            {
                Console.WriteLine("Parcel is less than 5 KG and greater than 1 KG, so categorized into Medium!");
            }
            else if (weight >= 5)
            {
                Console.WriteLine("Parcel is greater than or equal to 5 KG, so categorized into Heavy!");
            }
        }
        else
        {
            Console.WriteLine("Invalid weight entered. Please enter a numeric value.");
        }
        Console.WriteLine("------------------------------------------------");

        // User Authentication
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
                Console.WriteLine("Invalid Credentials!!");
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
                Console.WriteLine("Invalid Credentials!!");
            }
        }
        else
        {
            Console.WriteLine("Invalid Entry");
        }

        Console.WriteLine("------------------------------------------------");
        Console.ReadKey();
    }
}
