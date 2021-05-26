using CafeMVC.Application.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Menu
{
    public class MenuForCreationVm
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<ProductForListVm> MenuProducts { get; set; }

        public List<ProductForListVm> AllProducts { get; set; }


    }
}
