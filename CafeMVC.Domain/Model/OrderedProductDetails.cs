namespace CafeMVC.Domain.Model
{
    public class OrderedProductDetails : BaseModel
    {
        public int Quantity { get; set; }

        public decimal Discount { get; set; }

        public double BasePrice { get; set; }

        public double OverallPrice { get; set; } 

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}