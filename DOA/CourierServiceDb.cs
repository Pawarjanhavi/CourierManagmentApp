using System;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Entities;
using Util;


namespace DOA
{
    public class CourierServiceDb
    {
        private string connectionString = null;

        public CourierServiceDb()
        {
            // Set the connection string for the database
            connectionString = DBConnection.ReturnCn("dbCn");
        }

        // Method to insert a new courier
        public bool AddCourier(int courierId, string senderName, string senderAddress, string receiverName, string receiverAddress, decimal weight, string status, string trackingNumber, DateTime deliveryDate)
        {
            string query = "INSERT INTO Courier (CourierId, SenderName, SenderAddress, ReceiverName, ReceiverAddress, Weight, Status, TrackingNumber, DeliveryDate) " +
                           "VALUES (@CourierId, @SenderName, @SenderAddress, @ReceiverName, @ReceiverAddress, @Weight, @Status, @TrackingNumber, @DeliveryDate)";

            using (SqlConnection connection = new SqlConnection(connectionString))// Create a new instance of SqlConnection
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CourierId", courierId);
                        cmd.Parameters.AddWithValue("@SenderName", senderName);
                        cmd.Parameters.AddWithValue("@SenderAddress", senderAddress);
                        cmd.Parameters.AddWithValue("@ReceiverName", receiverName);
                        cmd.Parameters.AddWithValue("@ReceiverAddress", receiverAddress);
                        cmd.Parameters.AddWithValue("@Weight", weight);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@TrackingNumber", trackingNumber);
                        cmd.Parameters.AddWithValue("@DeliveryDate", deliveryDate);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        // Method to update courier status
        public bool UpdateCourierStatus(int courierId, string status)
        {
            string query = "UPDATE Courier SET Status = @Status WHERE CourierId = @CourierId"; // Ensure parameter name is consistent

            using (SqlConnection connection = new SqlConnection(connectionString))// Create a new instance of SqlConnection
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CourierId", courierId);
                        cmd.Parameters.AddWithValue("@Status", status);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        // Method to retrieve courier details by CourierID
        public void GetCourierDetails(int courierId)
        {
            string query = "SELECT * FROM Courier WHERE CourierId = @CourierId"; // Ensure parameter name is consistent

            using (SqlConnection connection = new SqlConnection(connectionString))// Create a new instance of SqlConnection
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CourierId", courierId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine($"Courier ID: {reader["CourierId"]}"); // Ensure column names match
                                    Console.WriteLine($"Sender Name: {reader["SenderName"]}");
                                    Console.WriteLine($"Sender Address: {reader["SenderAddress"]}");
                                    Console.WriteLine($"Receiver Name: {reader["ReceiverName"]}");
                                    Console.WriteLine($"Receiver Address: {reader["ReceiverAddress"]}");
                                    Console.WriteLine($"Weight: {reader["Weight"]}");
                                    Console.WriteLine($"Status: {reader["Status"]}");
                                    Console.WriteLine($"Tracking Number: {reader["TrackingNumber"]}");
                                    Console.WriteLine($"Delivery Date: {reader["DeliveryDate"]}");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No courier found with the given ID.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // Method to show all couriers
        public void ShowAllCouriers()
        {
            string query = "SELECT * FROM Courier";

            using (SqlConnection connection = new SqlConnection(connectionString)) // Create a new instance of SqlConnection
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"Courier ID: {reader["CourierId"]}"); // Ensure column names match
                                Console.WriteLine($"Sender Name: {reader["SenderName"]}");
                                Console.WriteLine($"Receiver Name: {reader["ReceiverName"]}");
                                Console.WriteLine($"Status: {reader["Status"]}");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No couriers found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // Method to generate and display shipment status report
        public void GenerateShipmentStatusReport()
        {
            string query = "SELECT Status, COUNT(*) AS Count FROM Courier GROUP BY Status";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Shipment Status Report:");
                        Console.WriteLine("Status\t\tCount");
                        Console.WriteLine("---------------------");
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Status"]}\t\t{reader["Count"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // Method to generate and display revenue report
        public void GenerateRevenueReport()
        {
            // Assuming a Cost field exists in the Courier table
            string query = "SELECT SUM(Weight) AS TotalWeight FROM Courier"; // Using Weight as a placeholder for Cost

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        object result = cmd.ExecuteScalar();
                        decimal totalWeight = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                        Console.WriteLine($"Total Weight of Shipments: {totalWeight} kg"); // Modify based on actual revenue calculation
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }



            
}
