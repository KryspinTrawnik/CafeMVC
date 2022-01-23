using System;
using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class Product :BaseModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<ProductIngredient> ProductIngredients { get; set; }

        public virtual ICollection<ProductAllergen> ProductAllergens { get; set; }

        public virtual ICollection<ProductDietInfoTag> ProductDietInfoTags { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
