﻿namespace AviShop.Data.Migrations
{
    using AviShop.Common;
    using AviShop.Model.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AviShop.Data.AviShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AviShop.Data.AviShopDbContext context)
        {
            CreateProductCategory(context);
            //  This method will be called after migrating to the latest version.
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new AviShopDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AviShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "avi",
            //    Email = "vinhlq010798@gmail.com",
            //    EmailConfirmed = true,
            //    Birthday = DateTime.Now,
            //    FullName = "Le Quang Vinh"
            //};

            //manager.Create(user,"123456$");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("vinhlq010798@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin","User" });
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            // context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Avi Le" },
            //      new Person { FullName = "Kim Yen" },
            //      new Person { FullName = "Vo Danh" },
            // );
            //
        }
        private void CreateProductCategory(AviShop.Data.AviShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() {Name="Điện lạnh", Alias="dien-lanh",Status=true },
                    new ProductCategory() {Name="Viễn thông", Alias="vien-thong",Status=true },
                    new ProductCategory() {Name="Đồ gia dụng", Alias="do-gia-dung",Status=true },
                    new ProductCategory() {Name="Mỹ phẩm", Alias="my-pham",Status=true },
                };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }            
        }
        private void CreateFooter(AviShopDbContext context)
        {
            if(context.Footers.Count(x=>x.ID == CommonConstants.DefaultFooterID) == 0)
            {
                string content = "";
            }
        }
    }
}
