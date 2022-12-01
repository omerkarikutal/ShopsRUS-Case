using Microsoft.EntityFrameworkCore;
using ShopsRUS.Core.Entity;
using ShopsRUS.Core.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.DataAccess.Concrete.Ef.Contexts
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base()
        {

        }
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }



        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasData(CreateData.CreateUsers());
            modelBuilder.Entity<UserType>()
            .HasData(CreateData.CreateUserTypes());
            modelBuilder.Entity<Product>()
            .HasData(CreateData.CreateProducts());
            modelBuilder.Entity<ProductType>()
            .HasData(CreateData.CreateProductTypes());
            modelBuilder.Entity<Discount>()
            .HasData(CreateData.CreateDiscounts());

            base.OnModelCreating(modelBuilder);
        }
    }
}
