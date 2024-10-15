using System;

namespace Entities
{
    public class Employee
    {
        // Private fields
        private int employeeID;
        private string employeeName;
        private string email;
        private string contactNumber;
        private string role;
        private double salary;

        // Default constructor
        public Employee() { }

        // Parameterized constructor
        public Employee(int employeeID, string employeeName, string email, string contactNumber, string role, double salary)
        {
            this.employeeID = employeeID;
            this.employeeName = employeeName;
            this.email = email;
            this.contactNumber = contactNumber;
            this.role = role;
            this.salary = salary;
        }

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        // ToString method
        public override string ToString()
        {
            return $"Employee: [EmployeeID={employeeID}, EmployeeName={employeeName}]";
        }
    }
}
