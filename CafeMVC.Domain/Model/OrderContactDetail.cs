namespace CafeMVC.Domain.Model
{
    public class OrderContactDetail
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ContactDetailId { get; set; }

        public ContactDetail ContactDetail { get; set; }

    }
}