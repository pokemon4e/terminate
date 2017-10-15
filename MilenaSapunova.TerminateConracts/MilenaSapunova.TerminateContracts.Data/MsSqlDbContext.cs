using Microsoft.AspNet.Identity.EntityFramework;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Model.Contracts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MilenaSapunova.TerminateContracts.Data.Models
{
    public class MsSqlDbContext : IdentityDbContext<User>
    {
        public MsSqlDbContext() : base("DbConnection", throwIfV1Schema: false)
        {
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(cancellationToken);
        }

        public static MsSqlDbContext Create()
        {
            return new MsSqlDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.OnUserModelCreating(modelBuilder);
            this.OnContractModelCreating(modelBuilder);
            this.OnTerminationNoticeCreating(modelBuilder);
            this.OnCompanyModelCreating(modelBuilder);
            this.OnAddressModelCreating(modelBuilder);
            this.OnCountryModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void OnUserModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Contracts)
                .WithRequired(c => c.Owner);

            modelBuilder.Entity<User>()
                .HasMany(u => u.TerminationNotices);
        }

        private void OnContractModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>()
                .Property(c => c.Title)
                .IsRequired()
                .HasColumnType("nvarchar");

            modelBuilder.Entity<Contract>()
                .Property(c => c.ContractNumber)
                .IsOptional()
                .HasColumnType("nvarchar");

            modelBuilder.Entity<Contract>()
                .Property(c => c.TerminationDate)
                .IsRequired()
                .HasColumnType("date");

            modelBuilder.Entity<Contract>()
                .Property(c => c.NotificationDate)
                .IsRequired()
                .HasColumnType("date");

            modelBuilder.Entity<Contract>()
               .HasRequired(c => c.Company);

            modelBuilder.Entity<Contract>()
               .HasOptional(c => c.TerminationNotice);
        }

        private void OnTerminationNoticeCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TerminationNotice>()
               .Property(t => t.Content)
               .IsRequired()
               .HasColumnType("ntext");

            modelBuilder.Entity<TerminationNotice>()
            .HasRequired(t => t.Company);

            modelBuilder.Entity<TerminationNotice>()
            .HasOptional(t => t.Company);

            modelBuilder.Entity<TerminationNotice>()
            .HasOptional(t => t.Contract);
        }

        private void OnCompanyModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
               .Property(c => c.Name)
               .IsRequired()
               .HasColumnType("nvarchar");

            modelBuilder.Entity<Company>()
              .Property(c => c.PhoneNumber)
              .IsRequired()
              .HasColumnType("nvarchar");

            modelBuilder.Entity<Company>()
             .Property(c => c.Email)
             .IsRequired()
             .HasColumnType("nvarchar");

            modelBuilder.Entity<Company>()
                .HasRequired(c => c.Address);
        }

        private void OnAddressModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
             .Property(a => a.Name)
             .IsRequired()
             .HasColumnType("nvarchar");

            modelBuilder.Entity<Address>()
               .HasRequired(a => a.Town);
        }

        private void OnCountryModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
            .Property(c => c.Name)
            .IsRequired()
            .HasColumnType("nvarchar");
        }
    }
}
