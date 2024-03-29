﻿using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class Customer  : BaseModel
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public virtual ICollection<PaymentCard> PaymentCards { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<ContactDetail> ContactDetails {get; set;}

        public virtual ICollection<Order> Orders { get; set; }

        public string UserCustomerDetailsId { get; set; }

        public UserCustomerDetails UserCustomerDetails { get; set; }
    }
}
