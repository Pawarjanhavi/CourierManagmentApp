using System;

namespace Entities
{
    public class Payment
    {
        // Private fields
        private long paymentID;
        private long courierID;
        private double amount;
        private DateTime paymentDate; // New field for payment date

        // Default constructor
        public Payment() { }

        // Parameterized constructor
        public Payment(long paymentID, long courierID, double amount, DateTime paymentDate)
        {
            this.paymentID = paymentID;
            this.courierID = courierID;
            this.amount = amount;
            this.paymentDate = paymentDate; // Initialize payment date
        }

        public long PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
        }

        public long CourierID
        {
            get { return courierID; }
            set { courierID = value; }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public DateTime PaymentDate // New property for payment date
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }

        // ToString method
        public override string ToString()
        {
            return $"Payment: [PaymentID={paymentID}, CourierID={courierID}, Amount={amount}, PaymentDate={paymentDate}]";
        }
    }
}
