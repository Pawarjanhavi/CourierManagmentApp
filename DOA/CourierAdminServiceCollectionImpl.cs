using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities;


namespace DOA
{
    public class CourierAdminServiceCollectionImpl : CourierUserServiceCollectionImpl, Interface.ICourierAdminService
    {
        private List<Employee> staffMembers;
        private int nextStaffId = 1; 

        // Constructor that initializes the companyObj and staffMembers
        public CourierAdminServiceCollectionImpl(CourierCompanyCollection companyCollection) : base(companyCollection)
        {
            staffMembers = new List<Employee>(); // Initialize the staff list
        }

        // Implementing AddCourierStaff method from ICourierAdminService
        public int AddCourierStaff(string name, string contactNumber)
        {
           
            Employee newStaff = new Employee(nextStaffId++, name, "staff@example.com", contactNumber, "Courier", 3000);
            staffMembers.Add(newStaff); 
            return newStaff.EmployeeID; 
        }

      
    }
}
