using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Infrastructur._Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructur.persistent.EF.ProductAgg
{
    internal class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {
        }
    }
}
