using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace kymcoLin_Entities.DBModels
{
    public partial class kymcolinContext : DbContext
    {
        public kymcolinContext()
        {
        }

        public kymcolinContext(DbContextOptions<kymcolinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<LicensePlate> LicensePlate { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Repair> Repair { get; set; }
        public virtual DbSet<RepairDetail> RepairDetail { get; set; }
        public virtual DbSet<UserData> UserData { get; set; }

        // Unable to generate entity type for table 'dbo.NumberRecord'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:kymcolin.database.windows.net,1433;Initial Catalog=kymcolin;Persist Security Info=False;User ID=linyuan;Password=Lin0928113951;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.Property(e => e.Account1).HasColumnName("Account");

                entity.Property(e => e.InputDate)
                    .HasColumnName("Input_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("Modify_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Permission).HasMaxLength(10);

                entity.Property(e => e.UserId).HasColumnName("User_ID");
            });

            modelBuilder.Entity<LicensePlate>(entity =>
            {
                entity.HasKey(e => e.LicensePlateNo);

                entity.Property(e => e.LicensePlateNo)
                    .HasColumnName("LicensePlate_No")
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.BirthDate)
                    .HasColumnName("Birth_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.BodyNo)
                    .HasColumnName("Body_No")
                    .HasMaxLength(50);

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.EngineNo)
                    .HasColumnName("Engine_No")
                    .HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.IdNo)
                    .HasColumnName("ID_No")
                    .HasMaxLength(20);

                entity.Property(e => e.InputDate)
                    .HasColumnName("Input_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InputName)
                    .HasColumnName("Input_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.LicenseDate)
                    .HasColumnName("License_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LicenseMemo).HasColumnName("License_Memo");

                entity.Property(e => e.ManufactureDate)
                    .HasColumnName("Manufacture_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("Modify_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyName)
                    .HasColumnName("Modify_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Tel).HasMaxLength(20);

                entity.Property(e => e.VenNo).HasColumnName("Ven_No");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.InputDate)
                    .HasColumnName("Input_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InputName)
                    .HasColumnName("Input_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("Modify_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyName)
                    .HasColumnName("Modify_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductName).HasColumnName("Product_Name");

                entity.Property(e => e.ProductPrice)
                    .HasColumnName("Product_Price")
                    .HasColumnType("money");

                entity.Property(e => e.ProductTypeNo).HasColumnName("Product_Type_No");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(e => e.ProductTypeNo);

                entity.Property(e => e.ProductTypeNo)
                    .HasColumnName("Product_Type_No")
                    .ValueGeneratedNever();

                entity.Property(e => e.InputDate)
                    .HasColumnName("Input_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InputName)
                    .HasColumnName("Input_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("Modify_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyName)
                    .HasColumnName("Modify_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProuctTypeName)
                    .HasColumnName("ProuctType_Name")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Repair>(entity =>
            {
                entity.Property(e => e.RepairId)
                    .HasColumnName("Repair_ID")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.DiscountPrice)
                    .HasColumnName("Discount_Price")
                    .HasColumnType("money");

                entity.Property(e => e.EngineerId)
                    .HasColumnName("Engineer_ID")
                    .HasMaxLength(6);

                entity.Property(e => e.InputDate)
                    .HasColumnName("Input_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InputName)
                    .HasColumnName("Input_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.LicensePlateNo)
                    .HasColumnName("LicensePlate_No")
                    .HasMaxLength(20);

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("Modify_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyName)
                    .HasColumnName("Modify_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.RepairDate)
                    .HasColumnName("Repair_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RepairMemo).HasColumnName("Repair_Memo");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("Total_Price")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<RepairDetail>(entity =>
            {
                entity.Property(e => e.RepairDetailId).HasColumnName("RepairDetail_ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.ProductName)
                    .HasColumnName("Product_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductPrice)
                    .HasColumnName("Product_Price")
                    .HasColumnType("money");

                entity.Property(e => e.ProductQuantity).HasColumnName("Product_Quantity");

                entity.Property(e => e.RepairDetailMemo).HasColumnName("RepairDetail_Memo");

                entity.Property(e => e.RepairId)
                    .HasColumnName("Repair_ID")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<UserData>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.ArrivalDate)
                    .HasColumnName("Arrival_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("Birth_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.IdNo)
                    .HasColumnName("ID_No")
                    .HasMaxLength(20);

                entity.Property(e => e.InputDate)
                    .HasColumnName("Input_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InputName)
                    .HasColumnName("Input_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.JobTitle)
                    .HasColumnName("Job_Title")
                    .HasMaxLength(10);

                entity.Property(e => e.LeaveDate)
                    .HasColumnName("Leave_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("Modify_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyName)
                    .HasColumnName("Modify_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .HasColumnName("User_Name")
                    .HasMaxLength(50);
            });
        }
    }
}
