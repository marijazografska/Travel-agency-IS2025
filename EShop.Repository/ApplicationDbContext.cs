using Eshop.DomainEntities;
using EShop.Domain.Domain;
using EShop.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EShop.Repository
{
    public class ApplicationDbContext : IdentityDbContext<EShopApplicationUser>
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ProductInShoppingCart> ProductInShoppingCarts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ProductInOrder> ProductInOrders { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<PlannedRoute> PlannedRoutes { get; set; }
        public DbSet<Activity> Activities { get; set; }




        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Itinerary)
                .WithOne(i => i.Product)
                .HasForeignKey<Itinerary>(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade); // Adjust delete behavior if necessary

            base.OnModelCreating(modelBuilder);
        }

    }
}
