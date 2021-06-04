using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Model
{
    public class ProductImage : BaseModel
    {
        public byte Image { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
