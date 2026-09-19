using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repositories;
using Shop.Infrastructur._Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructur.persistent.EF.SiteEntities.Repositories
{
    internal class SliderRepository : BaseRepository<Slider>, ISliderRepository
    {
        public SliderRepository(ShopContext context) : base(context)
        {
        }
    }
}
