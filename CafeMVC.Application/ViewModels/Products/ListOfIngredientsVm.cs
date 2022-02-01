using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Products
{
    public class ListOfIngredientsVm
    {
        public List<IngredientForViewVm> Ingredients { get; set; }

        public int Count { get; set; }
    }
}
