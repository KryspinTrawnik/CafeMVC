using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class PaymentCard : BaseModel
    {
        public string CardNumber { get; set; }

        public CardType CardType { get; set; }

        public int CardTypeId { get; set; }

        public string ExpirationDate { get; set; }

        public string CardHolderName { get; set; }

        public string SecureityCode { get; set; }

        public virtual Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}