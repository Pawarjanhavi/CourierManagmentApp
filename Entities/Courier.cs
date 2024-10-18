using System;

namespace Entities
{
    public class Courier
    {
        // Private fields
        private int courierID;
        private string senderName;
        private string senderAddress;
        private string receiverName;
        private string receiverAddress;
        private double weight;
        private string status;
        private string trackingNumber;
        private DateTime deliveryDate;
        private int userId; // Foreign key to User

        // Default constructor
        public Courier() { }

        // Parameterized constructor
        public Courier(int courierID, string senderName, string senderAddress, string receiverName,
                       string receiverAddress, double weight, string status, string trackingNumber,
                       DateTime deliveryDate, int userId)
        {
            this.courierID = courierID;
            this.senderName = senderName;
            this.senderAddress = senderAddress;
            this.receiverName = receiverName;
            this.receiverAddress = receiverAddress;
            this.weight = weight;
            this.status = status;
            this.trackingNumber = trackingNumber;
            this.deliveryDate = deliveryDate;
            this.userId = userId;
        }

        public int CourierID
        {
            get { return courierID; }
            set { courierID = value; }
        }

        public string SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }

        public string SenderAddress
        {
            get { return senderAddress; }
            set { senderAddress = value; }
        }

        public string ReceiverName
        {
            get { return receiverName; }
            set { receiverName = value; }
        }

        public string ReceiverAddress
        {
            get { return receiverAddress; }
            set { receiverAddress = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string TrackingNumber
        {
            get { return trackingNumber; }
            set { trackingNumber = value; }
        }

        public DateTime DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        // ToString method
        public override string ToString()
        {
            return $"Courier: [CourierID={courierID}, SenderName={senderName}, ReceiverName={receiverName}, Status={status}]";
        }
    }
}
