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

        public virtual ICollection<Ingredient> Ingredients { get; set; }

        public virtual ICollection<Allergen> Allergens { get; set; }

        public virtual ICollection<DietInformation> DietInformation { get; set; }
    }
}
