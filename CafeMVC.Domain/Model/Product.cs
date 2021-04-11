using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int TypeId { get; set; }

        public virtual Type Type { get; set; }

        public virtual DietInformation DietInformation {get; set;}

        public virtual ICollection<Ingredient> Ingredients { get; set; }

        public virtual ICollection<Allergen> Allergens { get; set; }

    }
}
