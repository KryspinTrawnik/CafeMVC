using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class ProductType : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
