using Hub.Models;
using Hub.Models.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hub.Models.Ecommerce.Admin;
using Hub.Models.RealEstate;

namespace Hub.Data
{
    public class HubDbContext : IdentityDbContext<HubUser,HubRole,Guid>
    {
        public HubDbContext(DbContextOptions<HubDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // modify db contex relation for foreign key relation with parent attribute
            builder.Entity<EcomCategory>()
           .HasOne(category => category.ParentEcomCategory)
           .WithMany(category => category.EcomCategories)
           .HasForeignKey(category => category.ParentcategoryId);

            base.OnModelCreating(builder);
        }

        public DbSet<Hub.Models.Admin.EcomCategory> EcomCategory { get; set; }

        public DbSet<Hub.Models.Admin.Module> Module { get; set; }

        public DbSet<Hub.Models.Admin.ModuleCategory> ModuleCategory { get; set; }

        public DbSet<Hub.Models.Ecommerce.Admin.Collection> Collection { get; set; }

        public DbSet<Hub.Models.Ecommerce.Admin.InventoryLocation> InventoryLocation { get; set; }

        public DbSet<Hub.Models.Ecommerce.Admin.Inventory> Inventory { get; set; }

        public DbSet<Hub.Models.Ecommerce.Admin.Product> Product { get; set; }

        public DbSet<Hub.Models.Ecommerce.Admin.ProductImage> ProductImage { get; set; }

        public DbSet<Hub.Models.Ecommerce.Admin.ProductOption> ProductOption { get; set; }

        public DbSet<Hub.Models.Ecommerce.Admin.ProductTag> ProductTag { get; set; }

        public DbSet<Hub.Models.Ecommerce.Admin.ProductVariant> ProductVariant { get; set; }

        public DbSet<Hub.Models.Ecommerce.Admin.Vendor> Vendor { get; set; }

        public DbSet<Hub.Models.CompanyProfile> CompanyProfile { get; set; }

        public DbSet<Hub.Models.CompanyUser> CompanyUser { get; set; }

        public DbSet<Hub.Models.HubAddress> HubAddress { get; set; }

        public DbSet<Hub.Models.RealEstate.RealEstateCategory> RealEstateCategory { get; set; }
    }
}
