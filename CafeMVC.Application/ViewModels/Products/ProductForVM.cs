using System.Collections.Generic;
using System.ComponentModel;

namespace CafeMVC.Application.ViewModels.Products
{
    public class ProductForVm
    {   
        public int Id { get; set; }

        public string Name { get; set; }
        
        public double Price { get; set;}

        public List<IngredientForVm> Ingredients { get; set; }

        public List<AllergenForVm> Allergens { get; set; }
    }
}

