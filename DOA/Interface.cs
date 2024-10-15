using Entities;
namespace DOA
{
    public class Interface
    {
        public interface ICourierUserService
        {
            string PlaceOrder(Courier courierObj);
            string GetOrderStatus(string trackingNumber);
            bool CancelOrder(string trackingNumber);
            List<Courier> GetAssignedOrders(int courierStaffId);
        }

        public interface ICourierAdminService
        {
            int AddCourierStaff(string name, string contactNumber);
        }

    }
}
