namespace CafeMVC.Domain.Model
{
    public class Payment : BaseModel
    {
        public PaymentCard PaymentCard { get; set; }

        public int? PaymentCardId { get; set; }

        public bool IsCompleted { get; set; } = false;

        public virtual PaymentType PaymentType { get; set; }

        public int PaymentTypeId { get; set; }
    }
}