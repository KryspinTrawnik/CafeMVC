using System.Collections.Generic;

namespace CafeMVC.Web.Models
{
    public class ProductForListVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public List<IngredientForVm> Ingredients { get; set; }

        public DietInfoForVM DietInformation { get; set; }
    }
}