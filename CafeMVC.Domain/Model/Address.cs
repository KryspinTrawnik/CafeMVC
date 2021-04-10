using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class Address
    {
        public string BuildingNumber { get; set; }

        public int FlatNumber { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public virtual AddressType AddressType { get; set; }
    }
}