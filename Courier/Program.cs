using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Entities;
using Exceptionlib;
using DOA;

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of the classes

        // User
        User user = new User(1, "John Doe", "john.doe@example.com", "password123", "1234567890", "123 Main St");
        Console.WriteLine(user);

        // Courier
        Courier courier = new Courier(1, "Alice Smith", "123 Elm St", "Bob Johnson", "456 Oak St", 5.0, "In Transit", "TRACK123", DateTime.Now.AddDays(3), user.UserID);
        Console.WriteLine(courier);

        // Employee
        Employee employee = new Employee(1, "Mark Brown", "mark.brown@example.com", "0987654321", "Courier", 3000);
        Console.WriteLine(employee);

        // Location
        Location location = new Location(1, "Warehouse A", "789 Pine St");
        Console.WriteLine(location);

        // Payment
        Payment payment = new Payment(1, courier.CourierID, 50.0, DateTime.Now);
        Console.WriteLine(payment);

        // Courier Company

        CourierCompany company1 = new CourierCompany("Fast Delivery Co.");
        CourierCompany company2 = new CourierCompany("Express Shipping Inc.");

        // Creating a CourierCompanyCollection and adding companies
        CourierCompanyCollection companyCollection = new CourierCompanyCollection(company1);
        companyCollection.AddCourierCompany(company2);

        // Display all courier companies
        companyCollection.DisplayCourierCompanies();

        // Create the CourierUserServiceImpl
        CourierUserServiceImpl userService = new CourierUserServiceImpl(company1);

        // Placing an order
        string placeOrderResult = userService.PlaceOrder(courier);
        Console.WriteLine(placeOrderResult);

        // Checking the status of the order
        string orderStatus = userService.GetOrderStatus("TRACK123");
        Console.WriteLine(orderStatus);

        // Cancelling the order
        bool cancelOrderResult = userService.CancelOrder("TRACK123");
        Console.WriteLine(cancelOrderResult ? "Order cancelled successfully." : "Failed to cancel order.");

        // Checking the status of the order after cancellation
        string newOrderStatus = userService.GetOrderStatus("TRACK123");
        Console.WriteLine(newOrderStatus);

        CourierAdminServiceImpl adminService = new CourierAdminServiceImpl(company1);

        // Add a new courier staff member
        int newStaffId1= adminService.AddCourierStaff("Raj Sharma", "123-456-7890");
        Console.WriteLine($"New staff member added with ID: {newStaffId1}");

        int newStaffId2 = adminService.AddCourierStaff("Ritu Pawar", "321-654-0987");
        Console.WriteLine($"New staff member added with ID: {newStaffId2}");


        /*var courierService = new CourierService();

         // Test Withdraw Amount
         try
         {
             courierService.WithdrawAmount("ABC123"); // Trying with a non-existing tracking number
         }
         catch (TrackingNumberNotFoundException ex)
         {
             Console.WriteLine($"Error: {ex.Message}");
         }
         catch (InvalidEmployeeIdException ex)
         {
             Console.WriteLine($"Error: {ex.Message}");
         }
         catch (Exception ex)
         {
             Console.WriteLine($"An unexpected error occurred: {ex.Message}");
         }
         finally
         {
             Console.WriteLine("End of transaction for withdrawal.");
         }

         // Test Validate Employee ID
         try
         {
             courierService.ValidateEmployeeId(9999); // Trying with a non-existing employee ID
         }
         catch (TrackingNumberNotFoundException ex)
         {
             Console.WriteLine($"Error: {ex.Message}");
         }
         catch (InvalidEmployeeIdException ex)
         {
             Console.WriteLine($"Error: {ex.Message}");
         }
         catch (Exception ex)
         {
             Console.WriteLine($"An unexpected error occurred: {ex.Message}");
         }
         finally
         {
             Console.WriteLine("End of employee validation.");
         }

         // Test valid employee ID (Optional)
         try
         {
             courierService.ValidateEmployeeId(1001); // This ID exists
             Console.WriteLine("Employee ID is valid.");
         }
         catch (InvalidEmployeeIdException ex)
         {
             Console.WriteLine($"Error: {ex.Message}");


         }*/




    }
}
