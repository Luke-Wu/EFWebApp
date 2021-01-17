using EFWebApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Context
{
    public class EFWebAppDbContext : DbContext, IEFWebAppDbContext
    {

        public EFWebAppDbContext() : base("EFWebAppDbContext")
        {
            // set the timeout of database to 2 minutes
            this.Database.CommandTimeout = 120;
        }

        public EFWebAppDbContext(string connectionString) : base(connectionString)
        {
            this.Database.CommandTimeout = 120;
        }

        public DbSet<Account> Accounts { get; set; }
        
        public DbSet<AccountType> AccountTypes { get; set; }

        public DbSet<AgeGroup> AgeGroups { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<PersonType> PersonTypes { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<SessionStatus> SessionStatuses { get; set; }

        public DbSet<SessionStatusType> SessionStatusTypes { get; set; }

        public DbSet<EFTimeZone> EFTimeZones { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<TransactionItem> TransactionItems { get; set; }

        public DbSet<TransactionType> TransactionTypes { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

          
           
          

        }





        #region Public Method


        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangeAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : Base
        {
            return base.Set<TEntity>();
        }

        public void SetAsAdded<TEntity>(TEntity entity) where TEntity : Base
        {
            UpdateEntityState<TEntity>(entity, EntityState.Added);
        }

        public void SetAsDeleted<TEntity>(TEntity entity) where TEntity : Base
        {
            UpdateEntityState<TEntity>(entity, EntityState.Deleted);
        }

        public void SetAsModified<TEntity>(TEntity entity) where TEntity : Base
        {
            UpdateEntityState<TEntity>(entity, EntityState.Modified);
        }
        #endregion

        #region Private Method




        private void UpdateEntityState<TEntity>(TEntity entity, EntityState entityState) where TEntity : Base
        {
            var dbEntityEntry = GetDbEntityEntrySafely(entity);
            dbEntityEntry.State = entityState;
        }

        private DbEntityEntry GetDbEntityEntrySafely<TEntity>(TEntity entity) where TEntity : Base
        {

            var dbEntityEntry = Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Set<TEntity>().Attach(entity);
            }
            else if (dbEntityEntry.State == EntityState.Added)
            {
                Set<TEntity>().Add(entity);
            }
            return dbEntityEntry;
        }

        #endregion


    }
}
