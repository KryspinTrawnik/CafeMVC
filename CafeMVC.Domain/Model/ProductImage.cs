using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Model
{
    public class ProductImage : BaseModel
    {
        public string FileName { get; set; }

        public byte[] Image { get; set; }

        public int ProductRef { get; set; }

        public Product Product { get; set; }
    }
}
