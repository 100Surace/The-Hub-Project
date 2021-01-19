using Hub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hub.Models.Organization;
using Hub.Models.Advertisement;
using Hub.Controllers.Info;
using Hub.Models.Event;
using Hub.Models.OrganizationFeature;
using Hub.Models.Extra;

namespace Hub.Data
{
    public class HubDbContext : IdentityDbContext<HubUser>
    {
        public HubDbContext(DbContextOptions<HubDbContext> options)
          : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Hub.Models.Organization.Module> Module { get; set; }
        public DbSet<Hub.Models.Organization.ModuleCategory> ModuleCategory { get; set; }
        public DbSet<Hub.Models.Organization.Org> Org { get; set; }
        public DbSet<Hub.Models.Organization.UserDetail> UserDetail { get; set; }
        public DbSet<Hub.Models.Advertisement.Adv> Adv { get; set; }
        public DbSet<Hub.Models.Advertisement.OrgFee> OrgFee { get; set; }
        public DbSet<Hub.Models.Advertisement.Annual> Annual { get; set; }
        public DbSet<Hub.Controllers.Info.NewsRegister> NewsRegister { get; set; }
        public DbSet<Hub.Models.Event.EventRego> EventRego { get; set; }
        public DbSet<Hub.Models.Event.EventApplyForm> EventApplyForm { get; set; }
        public DbSet<Hub.Models.OrganizationFeature.Comment> Comment { get; set; }
        public DbSet<Hub.Models.OrganizationFeature.CommentReply> CommentReply { get; set; }
        public DbSet<Hub.Models.OrganizationFeature.Fee> Fee { get; set; }
        public DbSet<Hub.Models.OrganizationFeature.Facility> Facility { get; set; }
        public DbSet<Hub.Models.OrganizationFeature.Rating> Rating { get; set; }
        public DbSet<Hub.Models.Extra.AdvOrderDetail> AdvOrderDetail { get; set; }
        public DbSet<Hub.Models.Extra.AnnualOrderDetail> AnnualOrderDetail { get; set; }
        public DbSet<Hub.Models.Extra.CashPayment> CashPayment { get; set; }
        public DbSet<Hub.Models.Extra.Coupon> Coupon { get; set; }
        public DbSet<Hub.Models.Extra.OrderHeader> OrderHeader { get; set; }
        public DbSet<Hub.Models.Extra.ShoppingCart> ShoppingCart { get; set; }
        public DbSet<Hub.Models.Extra.UserPayment> UserPayment { get; set; }
        public DbSet<Hub.Models.Extra.WatchList> WatchList { get; set; }

    }
   



 }
