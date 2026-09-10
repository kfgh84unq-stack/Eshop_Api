using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.RoleAgg
{
    public class Role:AggregateRoot
    {
        private Role()
        {
            
        }
        public Role(string title)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));

            Title = title;
            RolePermissions = new List<RolePermission>();
        }

        public Role(string title, List<RolePermission> rolePermissions)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));

            Title = title;
            RolePermissions = rolePermissions;
        }

        public string Title { get; private set; }
        public List<RolePermission> RolePermissions { get; private set; }

        public void SetPermissions(List<RolePermission> permissions)
        {
            RolePermissions=permissions;
        }
        public void Edit(string title)
        {
            NullOrEmptyDomainDataException.CheckString(title,nameof(title)) ;
            Title = title ;
        }
    }
}
