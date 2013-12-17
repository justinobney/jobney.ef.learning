using System.Data.Entity.ModelConfiguration;
using Jobney.EF.Learning.Models;

namespace Jobney.EF.Learning.Data.EFConfigurations
{
    public class ApiTokenConfiguration : EntityTypeConfiguration<ApiToken>
    {
        public ApiTokenConfiguration()
        {
            Property(x => x.Key)
                .IsRequired();

            Property(x => x.ValidUntil)
                .IsRequired();
        }
    }
}