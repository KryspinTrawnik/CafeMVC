﻿using System;
using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class Order : BaseModel
    {
        public DateTime LeadTime { get; set; }

        public DateTime DateOfOrder { get; set; }

        public decimal TotalPrice { get; set; }

        public string Note { get; set; }

        public string OrderConfirmation { get; set; }

        public decimal DeliveryCharge { get; set; }

        public bool IsCollection { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public int PaymantId { get; set; }

        public virtual Payment Payment { get; set; }

        public int StatusId { get; set; }

        public virtual Status Status { get; set; }

        public virtual ICollection<OrderAddress> OrderAddresses { get; set; }

        public virtual ICollection<OrderContactDetail> OrderContactDetails { get; set; }

        public virtual ICollection<OrderedProductDetails> OrderedProductsDetails { get; set; }

    }
}
