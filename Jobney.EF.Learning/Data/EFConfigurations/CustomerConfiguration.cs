using System.Data.Entity.ModelConfiguration;
using Jobney.EF.Learning.Models;

namespace Jobney.EF.Learning.Data.EFConfigurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(x => x.FirstName)
                .IsRequired();

            Property(x => x.LastName)
                .IsRequired();

            
        }
    }
}