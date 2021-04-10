using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Model
{
    public class MenuType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
