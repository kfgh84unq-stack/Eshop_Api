using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.CategoryAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.RoleAgg.Repository;
using Shop.Domain.SellerAgg;
using Shop.Domain.SiteEntities.Repositories;
using Shop.Domain.UserAgg.Repository;
using Shop.Infrastructur.persistent.EF.CategoryAgg;
using Shop.Infrastructur.persistent.EF.OrderAgg;
using Shop.Infrastructur.persistent.EF.ProductAgg;
using Shop.Infrastructur.persistent.EF.RoleAgg;
using Shop.Infrastructur.persistent.EF.SellerAgg;
using Shop.Infrastructur.persistent.EF.SiteEntities.Repositories;
using Shop.Infrastructur.persistent.EF.UserAgg;

namespace Shop.Infrastructur
{
    public class InfrastructureBootstrapper
    {
        public static void Init(IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IOrdreRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ISellerRepository, SellerRepository>();
            services.AddTransient<IBannerRepository, BannerRepository>();
            services.AddTransient<ISliderRepository, SliderRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
