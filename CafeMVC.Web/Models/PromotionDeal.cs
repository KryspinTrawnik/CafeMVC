using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMVC.Web.Models
{
    public class PromotionDeal
    {
       public int Id { get; set; }

       public string Name { get; set; }

       public double Price { get; set; }

       public List<Product> Products { get; set; }

    }
}
