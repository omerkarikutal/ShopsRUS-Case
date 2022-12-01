using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopsRUS.Business.Abstract;
using ShopsRUS.Business.Concrete;
using ShopsRUS.DataAccess.Abstract;
using ShopsRUS.DataAccess.Concrete.Ef;
using ShopsRUS.DataAccess.Concrete.Ef.Contexts;
using System.Reflection;

namespace ShopsRUS.Api.Extension
{
    public static class AppExtension
    {
        public static IServiceCollection UseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShopContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
        public static void CreateDb(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ShopContext>();
                context.Database.EnsureCreated();
            }
        }
        public static IServiceCollection DependencySet(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceDetailRepository, InvoiceDetailRepository>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IDiscountService, DiscountService>();
            return services;
        }

    }
}
