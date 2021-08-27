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

        public ICollection<Ingredient> Ingredients { get; set; }

        public ICollection<Allergen> Allergens { get; set; }

        public ICollection<DietInformation> DietInformation { get; set; }
    }
}
