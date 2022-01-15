using System.Collections;
using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class Ingredient : BaseModel
    {
        public string Name { get; set; }

        public ICollection<ProductIngredient> ProductIngredients { get; set; }
    }
}
