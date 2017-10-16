using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MilenaSapunova.TerminateContracts.Data.Models;
using MilenaSapunova.TerminateContracts.Model;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System;

namespace MilenaSapunova.TerminateContracts.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MsSqlDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MsSqlDbContext context)
        {
            this.SeedAdmin(context);
            this.SeedCountries(context);
        }

        private void SeedAdmin(MsSqlDbContext context)
        {
            const string AdministratorUserName = "admin";
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

        private void SeedCountries(MsSqlDbContext context)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "MilenaSapunova.TerminateContracts.Data.Resources.countries.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.RegisterClassMap<ContryMap>();
                    var countries = csvReader.GetRecords<Country>().ToArray();
                    context.Countries.AddOrUpdate(c => c.Name, countries);
                }
            }
        }

        private class ContryMap : ClassMap<Country>
        {
            public ContryMap()
            {
                Map(m => m.Name);
            }
        }
    }
}
