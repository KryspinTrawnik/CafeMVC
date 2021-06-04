using System;
using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class Order : BaseModel
    {
        public DateTime LeadTime { get; set; }

        public DateTime DateOfOrder { get; set; }

        public double TotalPrice { get; set; }

        public bool HasBeenDone { get; set; }

        public string Note { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public Address DeliveryAddress { get; set; }

        public Address BillingAddress { get; set; }

        public ICollection<Product> Products { get; set; }

        public int OrderConfirmation { get; set; }

        public bool IsCollection { get; set; }
    }
}
