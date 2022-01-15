using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Model
{
    public class ProductAllergen
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int AllergenId { get; set; }

        public Allergen Allergen { get; set; }
    }
}
