// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SVR.Data;

namespace SVR.Data.Migrations
{
    [DbContext(typeof(AppDataDbContext))]
    [Migration("20211201185219_InitialSetup")]
    partial class InitialSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SVR.Data.Entitites.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Landmark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Pincode")
                        .HasColumnType("int");

                    b.Property<int?>("StateCode")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("StateCode");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("SVR.Data.Entitites.Bill", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BilledCustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("BilledDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("BilledCustomerID");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("SVR.Data.Entitites.BillItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BillID")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("HSNCode")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("BillID");

                    b.ToTable("BillItems");
                });

            modelBuilder.Entity("SVR.Data.Entitites.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressID")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("GRNO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GSTIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PANNO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SVR.Data.Entitites.State", b =>
                {
                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Code");

                    b.ToTable("States");
                });

            modelBuilder.Entity("SVR.Data.Entitites.Address", b =>
                {
                    b.HasOne("SVR.Data.Entitites.State", "State")
                        .WithMany("Addresses")
                        .HasForeignKey("StateCode")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("State");
                });

            modelBuilder.Entity("SVR.Data.Entitites.Bill", b =>
                {
                    b.HasOne("SVR.Data.Entitites.Customer", "BilledCustomer")
                        .WithMany()
                        .HasForeignKey("BilledCustomerID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("BilledCustomer");
                });

            modelBuilder.Entity("SVR.Data.Entitites.BillItem", b =>
                {
                    b.HasOne("SVR.Data.Entitites.Bill", "Bill")
                        .WithMany("BillItems")
                        .HasForeignKey("BillID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Bill");
                });

            modelBuilder.Entity("SVR.Data.Entitites.Customer", b =>
                {
                    b.HasOne("SVR.Data.Entitites.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Address");
                });

            modelBuilder.Entity("SVR.Data.Entitites.Bill", b =>
                {
                    b.Navigation("BillItems");
                });

            modelBuilder.Entity("SVR.Data.Entitites.State", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
