using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class Allergen : BaseModel
    {
        public string Name { get; set; }

        public ICollection<ProductAllergen> ProductAllergens{ get; set; }
    }
}
