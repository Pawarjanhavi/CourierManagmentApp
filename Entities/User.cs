using System;

namespace Entities
{
    public class User
    {
       
        private int userID;
        private string userName;
        private string email;
        private string password;
        private string contactNumber;
        private string address;

        
        public User() { }

        
        public User(int userID, string userName, string email, string password, string contactNumber, string address)
        {
            this.userID = userID;
            this.userName = userName;
            this.email = email;
            this.password = password;
            this.contactNumber = contactNumber;
            this.address = address;
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        // ToString method
        public override string ToString()
        {
            return $"User: [UserID={userID}, UserName={userName}, Email={email}, ContactNumber={contactNumber}, Address={address}]";
        }
    }
}
