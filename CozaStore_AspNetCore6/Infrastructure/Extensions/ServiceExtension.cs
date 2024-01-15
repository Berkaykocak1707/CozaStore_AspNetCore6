using Business.Contracts;
using CozaStore_AspNetCore6.Models;
using DataAccess;
using DataAccess.Contracts;
using DataAccess.Repository;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Business;

namespace CozaStore_AspNetCore6.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sqlconnection"),
                    b => b.MigrationsAssembly("CozaStore_AspNetCore6"));

                options.EnableSensitiveDataLogging(true);
            });
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<CustomUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;
            })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("EditorOnly", policy => policy.RequireRole("Editor"));
            });

        }
        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "CozaStore_AspNetCore6.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new ResetLoadMoreFilter());
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(c => SessionCart.GetCart(c));
        }
        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ICouponRepository, CouponRepository>();
            services.AddScoped<IInformationRepository, InformationRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IWishListRepository, WishListRepository>();
            services.AddScoped<IWishListProductRepository, WishListProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<ICouponService, CouponManager>();
            services.AddScoped<IInformationService, InformationManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IStockService, StockManager>();
            services.AddScoped<IWishListService, WishListManager>();
            services.AddScoped<IWishListProductService, WishListProductManager>();
            services.AddScoped<SlugService>();
        }
        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });
        }
    }
}
