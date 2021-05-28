using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebCarRental.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebCarRental.Data
{
    public partial class CarRentalContext : DbContext
    {
        public CarRentalContext()
        {
        }

        public CarRentalContext(DbContextOptions<CarRentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdditionalService> AdditionalServices { get; set; }
        public virtual DbSet<CarBrand> CarBrands { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<RentalService> RentalServices { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlite("Data Source=C:\\Users\\Даша\\Source\\Repos\\Danya\\CarRental.db");
                optionsBuilder.UseSqlServer("Data Source=SSMLNSK;Initial Catalog=CarRental.db;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalService>(entity =>
            {
                entity.HasKey(e => e.ServiceCode);

                entity.Property(e => e.ServiceCode)
                    .HasColumnName("Service_code")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(255)");

                entity.Property(e => e.Price).HasColumnType("INT");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(255)");
            });

            modelBuilder.Entity<CarBrand>(entity =>
            {
                entity.HasKey(e => e.BrandCode);

                entity.Property(e => e.BrandCode)
                    .HasColumnName("Brand_code")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(150)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(50)");

                entity.Property(e => e.TechnicalSpecifications)
                    .IsRequired()
                    .HasColumnName("Technical_specifications")
                    .HasColumnType("NVARCHAR(100)");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.VehicleCode);

                entity.Property(e => e.VehicleCode)
                    .HasColumnName("Vehicle_code")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.BodyNumber)
                    .HasColumnName("Body_number")
                    .HasColumnType("INT");

                entity.Property(e => e.BrandCode)
                    .HasColumnName("Brand_code")
                    .HasColumnType("INT");

                entity.Property(e => e.CarPrice)
                    .HasColumnName("Car_price")
                    .HasColumnType("INT");

                entity.Property(e => e.DateOfLastMaintenance)
                    .IsRequired()
                    .HasColumnName("Date_of_last_maintenance")
                    .HasColumnType("DATE");

                entity.Property(e => e.EmployeeCode)
                    .HasColumnName("Employee_Code")
                    .HasColumnType("INT");

                entity.Property(e => e.EngineNumber)
                    .IsRequired()
                    .HasColumnName("Engine_number")
                    .HasColumnType("NVARCHAR(50)");

                entity.Property(e => e.Mileage).HasColumnType("INT");

                entity.Property(e => e.RegistrationNumber)
                    .HasColumnName("Registration_number")
                    .HasColumnType("NVARCHAR(255)");

                entity.Property(e => e.RentalDayPrice)
                    .HasColumnName("Rental_day_price")
                    .HasColumnType("INT");

                entity.Property(e => e.ReturnMark)
                    .IsRequired()
                    .HasColumnName("Return_mark")
                    .HasColumnType("NVARCHAR(255)");

                entity.Property(e => e.SpecialMarks)
                    .IsRequired()
                    .HasColumnName("Special_marks")
                    .HasColumnType("NVARCHAR (50)");

                entity.Property(e => e.YearOfRelease)
                    .HasColumnName("Year_of_release")
                    .HasColumnType("INT");

                entity.HasOne(d => d.EmployeeCodeNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.EmployeeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.BrandCodeNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.BrandCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.ClientCode);

                entity.Property(e => e.ClientCode)
                    .HasColumnName("Client_Code")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(255)");

                entity.Property(e => e.DateOfBirth)
                    .IsRequired()
                    .HasColumnName("Date_of_birth")
                    .HasColumnType("DATE");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("Full_name")
                    .HasColumnType("NVARCHAR (50)");

                entity.Property(e => e.PassportDetails)
                    .HasColumnName("Passport_details")
                    .HasColumnType("INT");

                entity.Property(e => e.Paul)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(10)");

                entity.Property(e => e.Phone).HasColumnType("INT");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PositionCode);

                entity.Property(e => e.PositionCode)
                    .HasColumnName("Position_code")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameOfThePosition)
                    .IsRequired()
                    .HasColumnName("Name_of_the_position")
                    .HasColumnType("NVARCHAR(50)");

                entity.Property(e => e.Requirements)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(100)");

                entity.Property(e => e.Responsibilities)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(100)");

                entity.Property(e => e.Salary).HasColumnType("INT");
            });

            modelBuilder.Entity<RentalService>(entity =>
            {
                entity.HasKey(e => e.ServicesId);

                entity.Property(e => e.ServicesId)
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientCode)
                    .HasColumnName("Client_Code")
                    .HasColumnType("INT");

                entity.Property(e => e.DateOfIssue)
                    .IsRequired()
                    .HasColumnName("Date_of_issue")
                    .HasColumnType("DATE");

                entity.Property(e => e.PaymentMark)
                    .IsRequired()
                    .HasColumnName("Payment_mark")
                    .HasColumnType("NVARCHAR(50)");

                entity.Property(e => e.RentalPeriod)
                    .IsRequired()
                    .HasColumnName("Rental_period")
                    .HasColumnType("NVARCHAR(50)");

                entity.Property(e => e.RentalPrice)
                    .HasColumnName("Rental_price")
                    .HasColumnType("INT");

                entity.Property(e => e.ReturnDate)
                    .IsRequired()
                    .HasColumnName("Return_Date")
                    .HasColumnType("DATE");

                entity.Property(e => e.ServiceCode1)
                    .HasColumnName("Service_code_1")
                    .HasColumnType("INT");

                entity.Property(e => e.ServiceCode2)
                    .HasColumnName("Service_code_2")
                    .HasColumnType("INT");

                entity.Property(e => e.ServiceCode3)
                    .HasColumnName("Service_code_3")
                    .HasColumnType("INT");

                entity.Property(e => e.VehicleCode)
                    .HasColumnName("Vehicle_code")
                    .HasColumnType("INT");

                entity.HasOne(d => d.ClientCodeNavigation)
                    .WithMany(p => p.RentalServices)
                    .HasForeignKey(d => d.ClientCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.VehicleCodeNavigation)
                    .WithMany(p => p.RentalServices)
                    .HasForeignKey(d => d.VehicleCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.EmployeeCode);

                entity.Property(e => e.EmployeeCode)
                    .HasColumnName("Employee_Code")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(255)");

                entity.Property(e => e.Age).HasColumnType("INT");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("Full_name")
                    .HasColumnType("NVARCHAR(50)");

                entity.Property(e => e.PassportDetails)
                    .HasColumnName("Passport_details")
                    .HasColumnType("INT");

                entity.Property(e => e.Paul)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(10)");

                entity.Property(e => e.Phone).HasColumnType("INT");

                entity.Property(e => e.PositionCode)
                    .HasColumnName("Position_code")
                    .HasColumnType("INT");

                entity.HasOne(d => d.PositionCodeNavigation)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.PositionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
