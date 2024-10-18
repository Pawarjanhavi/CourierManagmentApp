using System;
using Entities;
using Exceptionlib;
using DOA;

class Program
{
    static void Main(string[] args)
    {
        CourierServiceDb courierService = new CourierServiceDb();
        bool exit = false;

        while (!exit)
        {
            ShowMenu();
            int choice = GetMenuChoice();

            switch (choice)
            {
                case 1:
                    InsertCourier(courierService);
                    break;

                case 2:
                    UpdateCourierStatus(courierService);
                    break;

                case 3:
                    RetrieveCourierDetails(courierService);
                    break;

                case 4:
                    courierService.ShowAllCouriers();
                    break;

                case 5:
                    courierService.GenerateShipmentStatusReport();
                    break;

                case 6:
                    courierService.GenerateRevenueReport();
                    break;

                case 7:
                    exit = true;
                    Console.WriteLine("Exiting the application. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine("1. Insert Courier");
        Console.WriteLine("2. Update Courier Status");
        Console.WriteLine("3. Retrieve Courier Details");
        Console.WriteLine("4. Show All Couriers");
        Console.WriteLine("5. Generate Shipment Status Report");
        Console.WriteLine("6. Generate Revenue Report");
        Console.WriteLine("7. Exit");
        Console.Write("Choose an option: ");
    }

    private static int GetMenuChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 7)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 7.");
            Console.Write("Choose an option: ");
        }
        return choice;
    }

    private static void InsertCourier(CourierServiceDb courierService)
    {
        try
        {
            int courierId = GetCourierId();
            string senderName = GetStringInput("Enter Sender Name: ");
            string senderAddress = GetStringInput("Enter Sender Address: ");
            string receiverName = GetStringInput("Enter Receiver Name: ");
            string receiverAddress = GetStringInput("Enter Receiver Address: ");
            decimal weight = GetDecimalInput("Enter Weight: ");
            string status = GetStringInput("Enter Status: ");
            string trackingNumber = GetStringInput("Enter Tracking Number: ");
            DateTime deliveryDate = GetDateInput("Enter Delivery Date (yyyy-mm-dd): ");

            bool insertStatus = courierService.AddCourier(courierId, senderName, senderAddress, receiverName, receiverAddress, weight, status, trackingNumber, deliveryDate);
            Console.WriteLine(insertStatus ? "Courier inserted successfully." : "Failed to insert courier.");
        }
        catch (InvalidEmployeeIdException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void UpdateCourierStatus(CourierServiceDb courierService)
    {
        try
        {
            int courierIdToUpdate = GetCourierId();
            string newStatus = GetStringInput("Enter new status: ");

            bool updateStatus = courierService.UpdateCourierStatus(courierIdToUpdate, newStatus);
            Console.WriteLine(updateStatus ? "Courier status updated successfully." : "Failed to update status.");
        }
        catch (InvalidEmployeeIdException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void RetrieveCourierDetails(CourierServiceDb courierService)
    {
        try
        {
            int courierIdToFind = GetCourierId();
            courierService.GetCourierDetails(courierIdToFind);
        }
        catch (InvalidEmployeeIdException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (TrackingNumberNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static int GetCourierId()
    {
        Console.Write("Enter Courier ID: ");
        return GetIntegerInput();
    }

    private static int GetIntegerInput()
    {
        int value;
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("Invalid input. Please enter a valid integer: ");
        }
        return value;
    }

    private static decimal GetDecimalInput(string prompt)
    {
        Console.Write(prompt);
        decimal value;
        while (!decimal.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("Invalid input. Please enter a valid decimal value: ");
        }
        return value;
    }

    private static DateTime GetDateInput(string prompt)
    {
        Console.Write(prompt);
        DateTime date;
        while (!DateTime.TryParse(Console.ReadLine(), out date))
        {
            Console.Write("Invalid date input. Please enter a valid date (yyyy-mm-dd): ");
        }
        return date;
    }

    private static string GetStringInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? string.Empty; // Handles null case
    }
}
