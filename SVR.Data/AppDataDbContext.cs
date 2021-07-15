using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SVR.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Data
{
  public class AppDataDbContext:DbContext
    {       

        public AppDataDbContext(DbContextOptions<AppDataDbContext> options) : base(options)
        { 
        }

        
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>().ToTable("Bills"); 
            modelBuilder.Entity<Customer>().ToTable("Customers");

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

        
    }
}
