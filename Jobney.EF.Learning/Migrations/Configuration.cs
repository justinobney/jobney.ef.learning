using Jobney.EF.Learning.Data;
using Jobney.EF.Learning.Models;
using System.Data.Entity.Migrations;

namespace Jobney.EF.Learning.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Jobney.EF.Learning.Data.DataContext>
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
                    Email = "jim@aol.com"
                });
        }
    }
}
