using System.Collections.Generic;
using System.ComponentModel;

namespace CafeMVC.Application.ViewModels.Products
{
    public class ProductForVm
    {   
        [DisplayName("Numer")]
        public int Id { get; set; }

        [DisplayName("Produkt")]
        public string Name { get; set; }
        
        [DisplayName("Cena")]
        public double Price { get; set;}

        [DisplayName("Składniki")]
        public List<IngredientForVm> Ingredients { get; set; }

        public List<AllergensForVM> Allergens { get; set; }
    }
}

