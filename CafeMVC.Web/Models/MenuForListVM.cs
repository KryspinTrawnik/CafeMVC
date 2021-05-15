using System.Collections.Generic;
using System.ComponentModel;

namespace CafeMVC.Web.Models
{
    public class MenuForListVM
    {
        [DisplayName("Nr")]
        public int Id { get; set; }
        [DisplayName("Menu")]
        public string Name { get; set; }

      
    }
   

}
