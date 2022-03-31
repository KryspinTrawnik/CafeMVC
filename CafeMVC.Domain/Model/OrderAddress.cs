namespace CafeMVC.Domain.Model
{
    public class OrderAddress
    {
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}
