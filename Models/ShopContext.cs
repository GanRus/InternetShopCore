using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShopCore.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<GroupCategory> GroupCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<SmartPhoneProduct> SmartPhoneProducts { get; set; }
        public DbSet<TabletPCProduct> TabletPCProducts { get; set; }
        public DbSet<SmartWatchProduct> SmartWatchProducts { get; set; }
    }
}
