using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using Jobney.Core.Domain;
using Jobney.Core.Domain.Interfaces;
using Jobney.EF.Learning.Data.EFConfigurations;

namespace Jobney.EF.Learning.Data
{
    public class DataContext : DbContext, IDbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new ApiTokenConfiguration());
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : Entity {
            return base.Set<TEntity>(); ;
        }

        public new DbEntityEntry Entry<TEntity>(TEntity entity) where TEntity : Entity {
            return base.Entry(entity);
        }
    }
}