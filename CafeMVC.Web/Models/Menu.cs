using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMVC.Web.Models
{
    public class Menu
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Product> ListOfProducts {get; set; }
    }
    

}
