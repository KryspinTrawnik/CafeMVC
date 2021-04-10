using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Model
{
    public class Menu
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual MenuType MenuType { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
