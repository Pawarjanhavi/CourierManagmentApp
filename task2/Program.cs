public class Program
{
    private static void Main(string[] args)
    {
        //task2
        // 4. Display Customer Orders
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
            Console.WriteLine("No order");
        }
        Console.WriteLine("_________________________");
        Console.ReadKey();

        //Implement a while loop to track the real-time location of a courier until it reaches its destination

    }
}