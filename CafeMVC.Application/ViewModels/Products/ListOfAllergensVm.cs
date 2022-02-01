using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Products
{
    public class ListOfAllergensVm
    {
        public List<AllergenForViewVm> ListOfAllAllergens { get; set; }

        public int Count { get; set; }
    }
}
