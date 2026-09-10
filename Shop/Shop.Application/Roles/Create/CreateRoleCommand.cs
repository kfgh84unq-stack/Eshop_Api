using Common.Application;
using Shop.Domain.RoleAgg.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Roles.Create
{
    public record CreateRoleCommand(string Title, List<Permission> Permissions) : IBaseCommand;
}
