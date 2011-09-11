using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace mvcStore.Models
{
    public class StoreEntities : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
    }

    public class StoreInitializer : DropCreateDatabaseIfModelChanges<StoreEntities>
    {
        protected override void Seed(StoreEntities context)
        {
            //base.Seed(context);

            var prodTypes = new List<ProductType>
            {
                new ProductType { Name = "Good", Description = "something that can be packaged and shipped as a standalone product" },
                new ProductType { Name = "Service", Description = "add-ons, shipping, customization, etc." }
            };
            prodTypes.ForEach(pt => context.ProductTypes.Add(pt));
            context.SaveChanges();
        }
    }
}