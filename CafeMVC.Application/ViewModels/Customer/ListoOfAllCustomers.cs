﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class ListoOfAllCustomers
    {
        public List<CustomerForListVm> ListOfAllCustomers { get; set; }

        public int Count { get; set; }
    }
}