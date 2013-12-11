using System;
using System.Collections.Generic;
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
        private readonly Dictionary<Type, object> _dbSets;

        public DataContext()
            : base("DefaultConnection")
        {
            _dbSets = new Dictionary<Type, object>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new CustomerConfiguration());
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : Entity {
            if (_dbSets.ContainsKey(typeof (TEntity)))
                return _dbSets[typeof (TEntity)] as IDbSet<TEntity>;

            var dbSet = base.Set<TEntity>();
            _dbSets.Add(typeof (TEntity), dbSet);

            return dbSet;
        }

        public new DbEntityEntry Entry<TEntity>(TEntity entity) where TEntity : Entity {
            return base.Entry(entity);
        }
    }
}