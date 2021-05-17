﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMVC.Web.Models
{
    public class MenuForVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductForListVm> Products { get; set; }

        public int Count { get; set; }
    }

}
