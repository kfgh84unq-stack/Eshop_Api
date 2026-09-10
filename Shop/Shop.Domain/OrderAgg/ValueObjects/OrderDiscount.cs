using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class OrderDiscount:ValueObject
    {
        public string DiscountTitle { get; set; }
        public int DiscountAmount { get; set; }
    }
}
