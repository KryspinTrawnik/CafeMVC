using System.Collections.Generic;

namespace CafeMVC.Web.Models
{
    public class PromotionDeal
    {
       public int Id { get; set; }

       public string Name { get; set; }

       public double Price { get; set; }

       public List<ProductForVM> Products { get; set; }

    }
}
