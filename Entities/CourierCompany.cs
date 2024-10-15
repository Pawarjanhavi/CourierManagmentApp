namespace Entities
{
    public class CourierCompany
    {
        private string companyName;
        private List<Courier> courierDetails;
        private List<Employee> employeeDetails;
        private List<Location> locationDetails;

        public CourierCompany(string companyName) // Only the company name parameter
        {
            this.companyName = companyName;
            courierDetails = new List<Courier>();
            employeeDetails = new List<Employee>();
            locationDetails = new List<Location>();
        }

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public List<Courier> CourierDetails
        {
            get { return courierDetails; }
        }

        public List<Employee> EmployeeDetails
        {
            get { return employeeDetails; }
        }

        public List<Location> LocationDetails
        {
            get { return locationDetails; }
        }

        public override string ToString()
        {
            return $"CourierCompany [CompanyName={companyName}, CouriersCount={courierDetails.Count}, EmployeesCount={employeeDetails.Count}, LocationsCount={locationDetails.Count}]";
        }
    }
}
