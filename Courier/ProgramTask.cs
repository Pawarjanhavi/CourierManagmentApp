using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierApp
{
    public class ProgramTask
    {
        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("\n----- Menu -----");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Check Order Status");
                Console.WriteLine("2. Parcel Weight Categorization");
                Console.WriteLine("3. User Authentication");
                Console.WriteLine("4. Display Customer Orders");
                Console.WriteLine("5. Track Courier Location");
                Console.WriteLine("6. Find Nearest Available Courier");
                Console.WriteLine("7. Parcel Tracking");
                Console.WriteLine("8. Customer Data Validation");
                Console.WriteLine("9. Address Formatting");
                Console.WriteLine("10. Order Confirmation Email");
                Console.WriteLine("11. Calculate Shipping Cost");
                Console.WriteLine("12. Find Similar Address");
                Console.WriteLine("13. Password Generation");
                Console.WriteLine("0. Exit");
                Console.WriteLine("-------------------");
                Console.Write("Enter your choice : ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Task.CheckOrderStatus();
                        break;
                    case 2:
                        Task.ParcelWeightCategorization();
                        break;
                    case 3:
                        Task.UserAuthentication();
                        break;
                    case 4:
                        Task.DisplayCustomerOrders();
                        break;
                    case 5:
                        Task.TrackCourierLocation();
                        break;
                    case 6:
                        Task.FindNearestCourier();
                        break;
                    case 7:
                        Task.ParcelTracking();
                        break;
                    case 8:
                        Task.CustomerDataValidation();
                        break;
                    case 9:
                        Task.AddressFormatting();
                        break;
                    case 10:
                        Task.OrderConfirmationEmail();
                        break;
                    case 11:
                        Task.CalculateShippingCost();
                        break;
                    case 12:
                        Task.FindSimilarAddress();
                        break;
                    case 13:
                        Task.PasswordGeneration();
                        break;
                    case 0:
                        Console.WriteLine("Exiting the program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            } while (choice != 13);
        }

    }
}
