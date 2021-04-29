using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class ProductType : BaseModel
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public int ProductRef { get; set; }

        public Product Product { get; set; }
    }
}
