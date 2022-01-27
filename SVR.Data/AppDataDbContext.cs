using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SVR.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVR.Data
{
  public partial class AppDataDbContext:DbContext
    {       

        public AppDataDbContext(DbContextOptions<AppDataDbContext> options) : base(options)
        { 
        }

        
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address>  Addresses { get; set; }
        public DbSet<State> States { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=svr;Persist Security Info=False;Trusted_Connection=True;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            RemoveCascadeDelete(modelBuilder);
            //modelBuilder.Entity<Bill>().ToTable("Bills"); 
            //modelBuilder.Entity<Customer>().ToTable("Customers");

            //modelBuilder.Entity<Bill>(entity =>
            //{
            //   entity.

            //    entity.HasIndex(e => e.BilledCustomer)
            //        .HasName("IX_Contact")
            //        .IsUnique();


            //    entity.Property(e => e.CreatedBy).HasDefaultValueSql("((999))");

            //    entity.Property(e => e.CreatedDate)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Email)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.FirstName)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.IsActive)
            //        .IsRequired()
            //        .HasDefaultValue(true);

            //    entity.Property(e => e.LastName)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.MiddleName)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .HasDefaultValueSql("(space((1)))");

            //    entity.Property(e => e.ModifiedBy).HasDefaultValueSql("((999))");

            //    entity.Property(e => e.ModifiedDate)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.PhoneNumber)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.NotificationPrefEmail)
            //        .IsRequired()
            //        .HasDefaultValue(false);

            //    entity.Property(e => e.NotificationPrefCall)
            //        .IsRequired()
            //        .HasDefaultValue(false);

            //    entity.HasOne(d => d.ContactTitle)
            //        .WithMany(p => p.Contact)
            //        .HasForeignKey(d => d.ContactTitleId)
            //        .HasConstraintName("FK_Contact_ContactTitle");

            //    entity.HasOne(d => d.ContactType)
            //        .WithMany(p => p.Contact)
            //        .HasForeignKey(d => d.ContactTypeId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Contact_ContactType");

            //    entity.Property(e => e.WelcomeEmailSentDate)
            //      .HasColumnType("datetime");
            //});
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
           
            foreach (var entry in ChangeTracker.Entries<CommonEntity>())
            {
                var rowVersion = BitConverter.GetBytes(DateTime.UtcNow.Ticks);
                var dt = DateTimeOffset.UtcNow;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = dt;
                        entry.Entity.ModifiedOn = dt;
                        entry.Entity.CreatedBy ="Admin";
                        entry.Entity.ModifiedBy = "Admin";
                        entry.Entity.isActive = true;
                       // entry.Entity.RowVersion = rowVersion;

                        //if (entry.Entity.Active && entry.Entity.Deleted)
                        //{
                        //    entry.Entity.Active = false;
                        //}

                        //if (entry.Entity.Active)
                        //{
                        //    entry.Entity.ActiveFromDate = dt;
                        //}
                        //else
                        //{
                        //    entry.Entity.InActiveFromDate = dt;
                        //}
                        break;

                    //case EntityState.Modified:
                    //    entry.Entity.RowVersion = rowVersion;

                    //    if (entry.Entity.Active && entry.Entity.Deleted)
                    //    {
                    //        entry.Entity.Active = false;
                    //    }

                    //    if (!entry.Entity.Active)
                    //    {
                    //        entry.Entity.InActiveFromDate = dt;
                    //    }

                    //    break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> SaveSingleValueAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void RemoveCascadeDelete(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }

    }
}
