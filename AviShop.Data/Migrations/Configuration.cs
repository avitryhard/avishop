namespace AviShop.Data.Migrations
{
    using AviShop.Common;
    using AviShop.Model.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
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
            CreateSlide(context);
            CreatePage(context);
            CreateContactDetail(context);
            //  This method will be called after migrating to the latest version.
        }

        //    You can use the DbSet<T>.AddOrUpdate() helper extension method
        //    to avoid creating duplicate seed data.E.g.

        //   context.People.AddOrUpdate(
        //        p => p.FullName,
        //        new Person { FullName = "Avi Le" },
        //        new Person { FullName = "Kim Yen" },
        //        new Person { FullName = "Vo Danh" },

        //   );

        private void CreateUser(AviShopDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new AviShopDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AviShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "avi",
                Email = "vinhlq010798@gmail.com",
                EmailConfirmed = true,
                Birthday = DateTime.Now,
                FullName = "Le Quang Vinh"
            };

            manager.Create(user, "123456$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("vinhlq010798@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
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
            if (context.Footers.Count(x => x.ID == CommonConstants.DefaultFooterID) == 0)
            {
                string content = "";
            }
        }

        private void CreateSlide(AviShopDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlides = new List<Slide>
                {
                    new Slide(){
                        ID = 1,
                        Name ="Slide 1",
                        DisplayOrder =1,
                        Status =true,URL="#",
                        Image ="/Assets/client/images/bag.jpg",
                        Content =@"<h2>FLAT 50% 0FF</h2>
								<label>FOR ALL PURCHASE <b>VALUE</b></label>
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
								<span class=""on-get"">GET NOW</span>"},
                    new Slide(){
                        Name ="Slide 2",
                        DisplayOrder =1,
                        Status =true,
                        URL ="#",
                        Image ="/Assets/client/images/bag1.jpg",
                        Content =@"<h2>FLAT 50% 0FF</h2>
								<label>FOR ALL PURCHASE <b>VALUE</b></label>
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
								<span class=""on-get"">GET NOW</span>"},
                };
                context.Slides.AddRange(listSlides);
                context.SaveChanges();
            }
        }

        private void CreatePage(AviShopDbContext context)
        {
            if (context.Pages.Count() == 0)
            {
                var page = new Page()
                {
                    Name = "Giới thiệu",
                    Alias = "gioi-thieu",
                    Content = @"But I must explain to you how all this mistaken
                    idea of denouncing pleasure and praising pain was born and
                    I will give you a complete account of the system,
                    and expound the actual teachings of the great explorer of the truth,
                    the master-builder of human happiness. No one rejects, dislikes,
                    or avoids pleasure itself, because it is pleasure,
                    but because those who do not know how to pursue pleasure
                    rationally encounter consequences that are extremely painful.
                    Nor again is there anyone who loves or pursues or desires to obtain pain of itself,
                    because it is pain, but because occasionally circumstances occur in which toil
                    and pain can procure him some great pleasure. To take a trivial example,
                    which of us ever undertakes laborious physical exercise,
                    except to obtain some advantage from it? But who has any right to find fault
                    with a man who chooses to enjoy a pleasure that has no annoying consequences,
                    or one who avoids a pain that produces no resultant pleasure?",
                    Status = true
                };
                context.Pages.Add(page);
                context.SaveChanges();
            }
        }

        private void CreateContactDetail(AviShopDbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                try
                {
                    var contactDetail = new AviShop.Model.Models.ContactDetail()
                    {
                        Name = "Shop thời trang AVI",
                        Address = "Quận 12,Thành phố Hồ Chí Minh",
                        Email = "avitryhard@gmail.com",
                        Lat = 10.8817629,
                        Lng = 106.6385515,
                        Phone = "0123456789",
                        Website = "http://facebook.com/avile0107",
                        Other = "",
                        Status = true

                    };
                    context.ContactDetails.Add(contactDetail);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }

            }
        }
    }
}