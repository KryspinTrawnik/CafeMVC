using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Products
{
    public class ListOfAllergensVm
    {
        public List<AllergenForViewVm> ListOfAllAllergens { get; set; }

        public int Count { get; set; }
    }
}
