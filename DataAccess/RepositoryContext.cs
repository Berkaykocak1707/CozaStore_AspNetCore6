using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos;

namespace DataAccess
{
    public class RepositoryContext : IdentityDbContext<CustomUser>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options): base(options)
        {

        }
        public DbSet<About> Abouts
        {
            get; set;
        }
        public DbSet<Category> Categories
        {
            get; set;
        }
        public DbSet<Contact> Contacts
        {
            get; set;
        }
        public DbSet<Coupon> Coupons
        {
            get; set;
        }
        public DbSet<Information> Informations
        {
            get; set;
        }
        public DbSet<Product> Products
        {
            get; set;
        }
        public DbSet<Stock> Stocks
        {
            get; set;
        }
        public DbSet<WishList> WishLists
        {
            get; set;
        }
        public DbSet<WishListProduct> WishListProducts
        {
            get; set;
        }
        public DbSet<Order> Orders
        {
            get; set;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
