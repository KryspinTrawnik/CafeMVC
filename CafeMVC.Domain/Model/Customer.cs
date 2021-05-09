using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class Customer  : BaseModel
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public virtual CustomerContactInformation UserContactInformation {get; set;}

        public ICollection<Order> Orders { get; set; }
    }
}
