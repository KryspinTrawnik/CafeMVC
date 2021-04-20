﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Model
{
    public class Menu : BaseModel
    {

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
