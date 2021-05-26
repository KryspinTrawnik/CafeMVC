using System.Collections.Generic;
using System.ComponentModel;

namespace CafeMVC.Application.ViewModels.Products
{
    public class ProductForViewVm
    {   
        public int Id { get; set; }

        public string Name { get; set; }
        
        public double Price { get; set;}

        public List<IngredientForViewVm> Ingredients { get; set; }

        public List<AllergenForViewVm> Allergens { get; set; }
    }
}

