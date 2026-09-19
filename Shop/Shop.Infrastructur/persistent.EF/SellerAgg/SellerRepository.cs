using Shop.Domain.SellerAgg;
using Shop.Infrastructur._Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructur.persistent.EF.SellerAgg
{
    internal class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        public SellerRepository(ShopContext context) : base(context)
        {
        }

        public async Task<InventoryResult?> GetInventoryById(long id)
        {
            return await Context.Inventories.Where(r => r.Id == id)
           .Select(i => new InventoryResult()
           {
               Count = i.Count,
               Id = i.Id,
               Price = i.Price,
               ProductId = i.ProductId,
               SellerId = i.SellerId
           }).FirstOrDefaultAsync();
        }
    }
}
