using System;
using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class Order : BaseModel
    {
        public DateTime LeadTime { get; set; }

        public DateTime DateOfOrder { get; set; }

        public double Price { get; set; }

        public bool HasBeenDone { get; set; }

        public string Note { get; set; }

        public virtual int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<Product> Products { get; set; }

        public int OrderConfirmation { get; set; }

    }
}
