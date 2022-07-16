using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class CardType : BaseModel
    {
        public string Name { get; set; }

        public ICollection<PaymentCard> PaymentCards { get; set; }

    }
}