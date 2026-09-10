using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.SellerAgg.Services
{
    public interface ISellerDomainService
    {
        bool CheckOutInfo(Seller seller);
        bool IsNationalCodeExistInDataBase(string nationalCode);
    }
}
