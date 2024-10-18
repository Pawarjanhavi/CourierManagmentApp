using System.Collections.Generic;
using Entities;

namespace DOA
{
    public class CourierUserServiceImpl : Interface.ICourierUserService
    {
        protected CourierCompany companyObj;

        public CourierUserServiceImpl(CourierCompany company)
        {
            this.companyObj = company;
        }

        public string PlaceOrder(Courier courierObj)
        {
            if (courierObj != null)
            {
                companyObj.CourierDetails.Add(courierObj); // Directly add to the list
                return "Order placed successfully!";
            }
            return "Failed to place order: Courier object is null.";
        }

        public string GetOrderStatus(string trackingNumber)
        {
            foreach (var courier in companyObj.CourierDetails)
            {
                if (courier.TrackingNumber == trackingNumber)
                {
                    return $"Order Status: {courier.Status}";
                }
            }
            return "Order not found.";
        }

        public bool CancelOrder(string trackingNumber)
        {
            foreach (var courier in companyObj.CourierDetails)
            {
                if (courier.TrackingNumber == trackingNumber)
                {
                    courier.Status = "Cancelled"; // Update status to cancelled
                    return true;
                }
            }
            return false; // Order not found
        }

        public List<Courier> GetAssignedOrders(int courierStaffId)
        {
            
            return companyObj.CourierDetails; 
        }
    }
}
