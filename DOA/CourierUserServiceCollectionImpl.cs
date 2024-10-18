using Entities;
using System;
using System.Collections.Generic;

namespace DOA
{
    public class CourierUserServiceCollectionImpl : Interface.ICourierUserService
    {
        protected CourierCompanyCollection companyObj; // Variable to hold the CourierCompanyCollection

        // Constructor that initializes companyObj with the provided CourierCompanyCollection
        public CourierUserServiceCollectionImpl(CourierCompanyCollection companyCollection)
        {
            this.companyObj = companyCollection; // Initialize the companyObj
        }

        // Implementing methods from ICourierUserService
        public string PlaceOrder(Courier courierObj)
        {
            // Logic to place an order
            if (companyObj.couriercompanies.Count > 0)
            {
                // Adding the courier to the first company's list
                companyObj.couriercompanies[0].CourierDetails.Add(courierObj);
                return $"Order placed successfully for Courier ID: {courierObj.CourierID}";
            }
            return "No courier companies available to place an order.";
        }

        public string GetOrderStatus(string trackingNumber)
        {
            // Logic to get the order status based on the tracking number
            foreach (var company in companyObj.couriercompanies)
            {
                foreach (var courier in company.CourierDetails)
                {
                    if (courier.TrackingNumber == trackingNumber) // Assuming Courier has a TrackingNumber property
                    {
                        return $"Order Status for Tracking Number {trackingNumber}: {courier.Status}"; // Assuming Courier has a Status property
                    }
                }
            }
            return "Tracking number not found.";
        }

        public bool CancelOrder(string trackingNumber)
        {
            // Logic to cancel an order based on the tracking number
            foreach (var company in companyObj.couriercompanies)
            {
                foreach (var courier in company.CourierDetails)
                {
                    if (courier.TrackingNumber == trackingNumber)
                    {
                        courier.Status = "Cancelled"; // Update the status to cancelled
                        return true; // Successfully cancelled
                    }
                }
            }
            return false; // Tracking number not found
        }

        public List<Courier> GetAssignedOrders(int courierStaffId)
        {
            List<Courier> assignedOrders = new List<Courier>();

            // Logic to get assigned orders for a specific courier staff member
            foreach (var company in companyObj.couriercompanies)
            {
                foreach (var courier in company.CourierDetails)
                {
                    assignedOrders.Add(courier);
                }
            }

            return assignedOrders; // Return the list of all orders
        }

        public void AddCourierCompany(CourierCompany company)
        {
            companyObj.AddCourierCompany(company); // Use the method from the companyObj
        }

        
    }
}
