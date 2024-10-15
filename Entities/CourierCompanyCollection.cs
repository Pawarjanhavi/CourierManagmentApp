using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CourierCompanyCollection
    {
        // List to hold courier companies
        public List<CourierCompany> couriercompanies { get; set; }
        public CourierCompanyCollection(CourierCompany company)
        {
            couriercompanies = new List<CourierCompany>(); // Initialize the List
            this.couriercompanies.Add(company); // Add the provided company
        }

        // Method to add additional courier companies to the List
        public void AddCourierCompany(CourierCompany company)
        {
            this.couriercompanies.Add(company); // Add to the List
        }

        // Optional: Display all courier companies
        public void DisplayCourierCompanies()
        {
            foreach (var company in couriercompanies)
            {
                Console.WriteLine($"Company Name: {company.CompanyName}");
            }
        }
    }
}
