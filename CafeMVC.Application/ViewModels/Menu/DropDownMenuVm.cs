using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CafeMVC.Application.ViewModels.Menu
{
    public class DropDownMenuVm
    {
        public int Id { get; set; }

        public List<SelectListItem> Items { get; set; }
    }
}
