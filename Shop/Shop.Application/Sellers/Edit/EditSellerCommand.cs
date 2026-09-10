using Common.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Sellers.Edit
{
    public record EditSellerCommand(long Id, string ShopName, string NationalCode) : IBaseCommand;
}
