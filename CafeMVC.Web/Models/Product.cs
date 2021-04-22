using System.Collections.Generic;
using System.ComponentModel;

namespace CafeMVC.Web.Models
{
    public class Product
    {   
        [DisplayName("Numer")]
        public int Id { get; set; }

        [DisplayName("Produkt")]
        public string Name { get; set; }

        public int Type { get; set; }
        
        [DisplayName("Cena")]
        public double Price { get; set;}

        [DisplayName("Składniki")]
        public List<Ingredient> Ingredients { get; set; }

        public List<Allergens> Allergens { get; set; }
    }
}

