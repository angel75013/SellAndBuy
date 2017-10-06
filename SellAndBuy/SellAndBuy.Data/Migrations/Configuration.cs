using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json.Linq;
using SellAndBuy.Data.Models;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SellAndBuy.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<SqlDbContext>
    {
        const string ProvinceFileJson = "SellAndBuy.Data.Ressources.provinces-bg.json";
        const string CitiesFileJson = "SellAndBuy.Data.Ressources.province-cities-bg.json";

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SqlDbContext context)
        {
            this.SeedAdmin(context);
            this.SeedProvinces(context);
            this.SeedCities(context);

            base.Seed(context);
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

        private void SeedProvinces(SqlDbContext context)
        {
            var provincesJsonAll = GetEmbeddedResourceAsString(ProvinceFileJson);

            JArray jsonprovincesJsonAll = JArray.Parse(provincesJsonAll) as JArray;

            foreach (var province in jsonprovincesJsonAll)
            {
                context.Provinces.Add(new Province
                {
                    ProvinceName = (string)province
                });

            }
            context.SaveChanges();
        }

        private void SeedCities(SqlDbContext context)
        {
            var citiesJsonAll = GetEmbeddedResourceAsString(CitiesFileJson);

            JArray jsonCitiesJsonAll = JArray.Parse(citiesJsonAll) as JArray;

            foreach (var obj in jsonCitiesJsonAll)
            {
                var provenceName = obj["Province"].ToString();
                var currentProvince = context.Provinces.FirstOrDefault(x => x.ProvinceName == provenceName);

                if (currentProvince == null)
                {
                    var newProvince = new Province
                    {
                        ProvinceName = provenceName
                    };
                    context.Provinces.AddOrUpdate(newProvince);
                    context.SaveChanges();
                    currentProvince = context.Provinces.First(x => x.ProvinceName == provenceName);
                }

                foreach (var city in obj["Cities"])
                {
                    var newCity = new City
                    {
                        Name = city.ToString(),
                        ProvinceId = currentProvince.Id
                    };
                    context.Cities.AddOrUpdate(newCity);
                }
            }
        }

        private string GetEmbeddedResourceAsString(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            string result;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
