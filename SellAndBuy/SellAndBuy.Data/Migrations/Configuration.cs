using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SellAndBuy.Data.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq; 

namespace SellAndBuy.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<SellAndBuy.Data.SqlDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SellAndBuy.Data.SqlDbContext context)
        {
            this.SeedAdmin(context);
        }

        private void SeedAdmin(SqlDbContext context)
        {
            const string AdministratorUserName = "info@telerikacademy.com";
            const string AdministratorPassword = "123456";

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdministratorUserName, Email = AdministratorUserName, EmailConfirmed = true };
                userManager.Create(user, AdministratorPassword);

                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
