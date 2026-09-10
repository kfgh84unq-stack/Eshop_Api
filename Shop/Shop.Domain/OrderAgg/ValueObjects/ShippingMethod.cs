using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class ShippingMethod:ValueObject
    {
        public string ShippingType { get;private set; }
        public int ShippingCost { get; private set; }
    }
}
