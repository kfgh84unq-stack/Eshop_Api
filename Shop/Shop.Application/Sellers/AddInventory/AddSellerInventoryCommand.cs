using Common.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Sellers.AddInventory
{
    public class AddSellerInventoryCommand: IBaseCommand
    {
        public AddSellerInventoryCommand(long sellerId, long productId, int count, int price, int? discountPercentage)
        {
            SellerId = sellerId;
            ProductId = productId;
            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }

        public long SellerId { get; internal set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? DiscountPercentage { get; private set; }
    }
}
