namespace CafeMVC.Domain.Model
{
    public class ProductDietInfoTag
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int DietInfoTagId { get; set; }

        public virtual DietInfoTag DietInfoTag { get; set; }
    }
}
