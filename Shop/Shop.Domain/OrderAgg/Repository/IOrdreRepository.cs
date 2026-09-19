using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.OrderAgg.Repository
{
    public interface IOrdreRepository:IBaseRepository<Order>
    {
        Task<Order?> GetCurrentOrder(long userId);
    }
}
