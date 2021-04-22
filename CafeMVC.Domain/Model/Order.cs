using System;
using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class Order : BaseModel
    {
        public DateTime LeadTime { get; set; }

        public double Price { get; set; }

        public bool HasBeenDone { get; set; }

        public string Note { get; set; }

        public virtual int UserId { get; set; }

        public virtual User User { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
