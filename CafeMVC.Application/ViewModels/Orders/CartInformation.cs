namespace CafeMVC.Application.ViewModels.Orders
{
    public class CartInformation
    {
        public bool IsCollection { get; set; }

        public int PaymentTypeId { get; set; }

        public string PaymentName { get; set; }

        public string Postcode { get; set; }

        public int CustomerId { get; set; }

        public int AddressId { get; set; }
    }
}
