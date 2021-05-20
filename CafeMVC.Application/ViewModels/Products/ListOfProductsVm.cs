using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Products
{
    public class ListOfProductsVm
    {
        public List<ProductForListVm> ListOfAllProducts { get; set; }

        public int Count { get; set; }
    }
}
