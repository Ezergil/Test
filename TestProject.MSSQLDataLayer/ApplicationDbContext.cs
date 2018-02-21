using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using TestProject.Abstraction;
using TestProject.Domain;

namespace TestProject.MSSQLDataLayer
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public ApplicationDbContext() : base("ConnectionString")
        {
            
        }

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(s => s.Parents)
                .WithMany(c => c.Users)
                .Map(cs =>
                {
                    cs.MapLeftKey("UserId");
                    cs.MapRightKey("GroupId");
                    cs.ToTable("UserGroups");
                });

            modelBuilder.Entity<Group>()
                .HasMany(s => s.Parents)
                .WithMany()
                .Map(cs =>
                {
                    cs.MapLeftKey("ChildGroupId");
                    cs.MapRightKey("ParentGroupId");
                    cs.ToTable("GroupRelations");
                }); ;
            base.OnModelCreating(modelBuilder);
        }

        #region IDbContext

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public void SetAsAdded<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Added);
        }

        public void SetAsModified<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Modified);
        }

        public void SetAsDeleted<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Deleted);
        }

        public async Task<int> CommitAsync()
        {
            try
            {
                var saveChangesAsync = await SaveChangesAsync();
                return saveChangesAsync;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        private void UpdateEntityState<TEntity>(TEntity entity, EntityState entityState) where TEntity : BaseEntity
        {
            var dbEntityEntry = GetDbEntityEntrySafely(entity);
            dbEntityEntry.State = entityState;
        }

        private DbEntityEntry GetDbEntityEntrySafely<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var dbEntityEntry = Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Set<TEntity>().Attach(entity);
            }
            return dbEntityEntry;
        }
        #endregion


    }
}