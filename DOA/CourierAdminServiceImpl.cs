using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOA
{
    public class CourierAdminServiceImpl : CourierUserServiceImpl, Interface.ICourierAdminService
    {
        private List<Employee> staffMembers; // To hold the list of courier staff members
        private int nextStaffId = 1; // To generate unique staff IDs

        public CourierAdminServiceImpl(CourierCompany company) : base(company)
        {
            staffMembers = new List<Employee>();
        }

        public int AddCourierStaff(string name, string contactNumber)
        {
            Employee newStaff = new Employee(nextStaffId++, name, "staff@example.com", contactNumber, "Courier", 3000);
            staffMembers.Add(newStaff);
            return newStaff.EmployeeID; // Assuming Employee has an EmployeeID property
        }


    }
}
