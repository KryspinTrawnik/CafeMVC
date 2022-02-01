namespace CafeMVC.Domain.Model
{
    public class ProductDietInfoTag
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int DietInfoTagId { get; set; }

        public DietInfoTag DietInfoTag { get; set; }
    }
}
