using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class Status : BaseModel
    {
        public string Name { get; set; }

        ICollection<Order> Orders { get; set; }
    }
}