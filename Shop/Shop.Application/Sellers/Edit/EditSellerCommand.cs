using Common.Application;
using Shop.Domain.SellerAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Sellers.Edit
{
    public record EditSellerCommand(long Id, string ShopName, string NationalCode, SellerStatus Status) : IBaseCommand;
}
