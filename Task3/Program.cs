//Task 3: Arrays and Data Structures
public class Program
{
    private static void Main(string[] args)
    {

        //7Tracking Location of a Courier

        Console.WriteLine("Tracking History:");

        // Create a simple array to store the tracking history of a parcel
        string[] trackingHistory = new string[3];
        trackingHistory[0] = "Sender Location , 2024-10-01 10:00:00";
        trackingHistory[1] = "In Transit , 2024-10-05 13:15:00";
        trackingHistory[2] = "Receiver's Location , 2024-10-15 12:45:00";

        // Display the tracking history
        foreach (var update in trackingHistory)
        {
            Console.WriteLine(update);
        }
        Console.WriteLine("_________________________");

        //8. Implement a method to find the nearest available courier for a new order using an array of couriers. 

        // Array of couriers using tuples
        var couriers = new (string Name, double Latitude, double Longitude, bool IsAvailable)[]
         {
             ("Courier A", 37.7749, -122.4194, true),
             ("Courier B", 40.7128, -74.0060, false),
             ("Courier C", 34.0522, -118.2437, true)
         };

        // Find the nearest available courier based on the user's location
        var nearest = FindNearestCourier(couriers, 36.7783, -119.4179);  // Example user's location

        // Output the result
        if (nearest != null)
            Console.WriteLine("Nearest available courier: " + nearest.Value.Name);
        else
            Console.WriteLine("No available couriers.");
    }

    // Method to find the nearest available courier

    static (string Name, double Latitude, double Longitude, bool IsAvailable)? FindNearestCourier(
        (string Name, double Latitude, double Longitude, bool IsAvailable)[] couriers,
        double userLat, double userLon)

    {
        (string Name, double Latitude, double Longitude, bool IsAvailable)? nearest = null;  // To store the nearest available courier
        double minDistance = double.MaxValue;  // Start with a large number for the minimum distance

        foreach (var courier in couriers)  // Loop through all couriers
        {
            if (!courier.IsAvailable)  // Skip if the courier is not available
                continue;

            // Calculate the distance using the Euclidean distance formula
            double distance = Math.Sqrt(
                Math.Pow(courier.Latitude - userLat, 2) +
                Math.Pow(courier.Longitude - userLon, 2));

            // If this courier is closer, update the nearest courier and the minimum distance
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = courier;
            }
        }

        return nearest;
        Console.WriteLine("_________________________");
        Console.ReadKey();

    }
}