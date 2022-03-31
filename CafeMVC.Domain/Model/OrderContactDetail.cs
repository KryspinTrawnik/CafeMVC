namespace CafeMVC.Domain.Model
{
    public class OrderContactDetail
    {
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int ContactDetailId { get; set; }

        public virtual ContactDetail ContactDetail { get; set; }

    }
}