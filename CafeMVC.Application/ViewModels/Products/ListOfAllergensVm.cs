using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Products
{
    public class ListOfAllergensVm
    {
        public List<AllergenForViewVm> ListOfAllergens { get; set; }

        public int Count { get; set; }

        public int PageSize { get; internal set; }
        
        public int CurrentPage { get; internal set; }
        
        public string SearchString { get; internal set; }
    }
}
