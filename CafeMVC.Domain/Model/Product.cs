using System;
using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class Product :BaseModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int TypeId { get; set; }

        public ProductType ProductType{ get; set; }

        public DietInformation DietInformation {get; set;}

        public ProductImage ProductImage { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public ICollection<Allergen> Allergens { get; set; }

    }
}
