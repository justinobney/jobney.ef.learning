using System.Linq;
using System.Web.Security;
using Jobney.EF.Learning.Common;
using Jobney.EF.Learning.Data;
using Jobney.EF.Learning.Models;
using System.Data.Entity.Migrations;
using WebMatrix.WebData;

namespace Jobney.EF.Learning.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext context)
        {
            context.Set<Customer>().AddOrUpdate(
                c => c.Email,
                new Customer
                {
                    FirstName = "Jim",
                    LastName = "Smith",
                    Email = "admin@admin.com"
                });

            context.SaveChanges();
            
            InitializeMembership();

        }

        private static void InitializeMembership()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "Customer", "Id", "Email", autoCreateTables: true);
            }

            Setup.ConfigureSecurityRolesIfNotExist();

            if (!WebSecurity.UserExists("admin@admin.com"))
            {
                WebSecurity.CreateAccount("admin@admin.com", "password");
            }

            if (!Roles.GetRolesForUser("admin@admin.com").ToList().Contains(Constants.ROLES_ADMINISTRATOR))
            {
                Roles.AddUsersToRoles(new[] { "admin@admin.com" }, new[] { Constants.ROLES_ADMINISTRATOR });
            }
        }
    }
}
