using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Model
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime LeadTime { get; set; }

        public double Price { get; set; }

        public bool HasBeenDone { get; set; }

        public string Note { get; set; }

        public virtual int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
