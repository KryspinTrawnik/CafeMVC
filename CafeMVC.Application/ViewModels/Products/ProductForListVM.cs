using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Products
{
    public class ProductForListVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public List<IngredientForViewVm> Ingredients { get; set; }

        public DietInfoForViewVm DietInformation { get; set; }
    }
}