using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class PaymentType : BaseModel
    {
        public string Name { get; set; }

        public ICollection<Payment> Payments{ get; set; }
    }
}