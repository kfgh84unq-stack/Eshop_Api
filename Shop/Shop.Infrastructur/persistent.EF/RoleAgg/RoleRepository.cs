using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;
using Shop.Infrastructur._Utilities;
using Shop.Infrastructur.persistent.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructur.persistent.EF.RoleAgg
{
    internal class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ShopContext context) : base(context)
        {
        }
    }
}
