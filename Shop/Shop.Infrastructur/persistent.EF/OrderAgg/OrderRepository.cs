using Microsoft.EntityFrameworkCore;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Infrastructur._Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructur.persistent.EF.OrderAgg
{
    internal class OrderRepository : BaseRepository<Order>, IOrdreRepository
    {
        public OrderRepository(ShopContext context) : base(context)
        {
        }

        public async Task<Order?> GetCurrentOrder(long userId)
        {
            return await Context.Orders.AsTracking().FirstOrDefaultAsync(f=> f.UserId == userId
            && f.Status == OrderStatus.Pennding);
        }
    }
}
