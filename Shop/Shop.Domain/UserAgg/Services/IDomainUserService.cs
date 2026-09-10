using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.UserAgg.Services
{
    public interface IDomainUserService
    {
        bool IsEmailExist(string email);
        bool IsPhoneNamberExist(string phone);
    }
}
