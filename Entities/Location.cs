using System;

namespace Entities
{
    public class Location
    {
        // Private fields
        private int locationID;
        private string locationName;
        private string address;

        // Default constructor
        public Location() { }

        // Parameterized constructor
        public Location(int locationID, string locationName, string address)
        {
            this.locationID = locationID;
            this.locationName = locationName;
            this.address = address;
        }

        public int LocationID
        {
            get { return locationID; }
            set { locationID = value; }
        }

        public string LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        // ToString method
        public override string ToString()
        {
            return $"Location: [LocationID={locationID}, LocationName={locationName}]";
        }
    }
}
