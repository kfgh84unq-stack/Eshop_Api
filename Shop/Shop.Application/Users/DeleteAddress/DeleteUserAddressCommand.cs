using Common.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Users.DeleteAddress
{
    public record DeleteUserAddressCommand(long UserId, long UserAddressId) : IBaseCommand;
}
