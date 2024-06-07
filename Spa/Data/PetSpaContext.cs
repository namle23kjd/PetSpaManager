using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Spa.Models;

namespace Spa.Data;

public partial class PetSpaContext : DbContext
{
    public PetSpaContext()
    {
    }

    public PetSpaContext(DbContextOptions<PetSpaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingDetail> BookingDetails { get; set; }

    public virtual DbSet<Combo> Combos { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-LJMA02H\\PIEDTEAM;Database=Pet_Spa;User Id=SA;Password=12345;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__AD050086168743E5");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.Id, "UQ_Admin_Id").IsUnique();

            entity.Property(e => e.AdminId)
                .ValueGeneratedNever()
                .HasColumnName("adminID");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admin_AspNetUsers");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Discriminator).HasMaxLength(21);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.RefreshToken).HasColumnName("refreshToken");
            entity.Property(e => e.RefreshTokenExpiry).HasColumnName("refreshTokenExpiry");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__C6D03BEDDB4CC5ED");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("bookingID");
            entity.Property(e => e.BookingSchedule)
                .HasColumnType("datetime")
                .HasColumnName("bookingSchedule");
            entity.Property(e => e.CusId).HasColumnName("cusID");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.Feedback)
                .HasColumnType("text")
                .HasColumnName("feedback");
            entity.Property(e => e.ManaId).HasColumnName("manaID");
            entity.Property(e => e.StaffId).HasColumnName("staffID");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalAmount");

            entity.HasOne(d => d.Cus).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__cusID__4AB81AF0");

            entity.HasOne(d => d.Mana).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ManaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_Manager");

            entity.HasOne(d => d.Staff).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK_Booking_Staff");
        });

        modelBuilder.Entity<BookingDetail>(entity =>
        {
            entity.HasKey(e => e.BookingDetailId).HasName("PK__Booking___942CA05E22BB22C8");

            entity.ToTable("Booking_Detail");

            entity.Property(e => e.BookingDetailId)
                .ValueGeneratedNever()
                .HasColumnName("bookingDetailID");
            entity.Property(e => e.BookingId).HasColumnName("bookingID");
            entity.Property(e => e.ComboId).HasColumnName("comboID");
            entity.Property(e => e.ComboType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("comboType");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.PetId).HasColumnName("petID");
            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingDetails)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking_D__booki__571DF1D5");

            entity.HasOne(d => d.Combo).WithMany(p => p.BookingDetails)
                .HasForeignKey(d => d.ComboId)
                .HasConstraintName("FK__Booking_D__combo__5535A963");

            entity.HasOne(d => d.Pet).WithMany(p => p.BookingDetails)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking_D__petID__5441852A");

            entity.HasOne(d => d.Service).WithMany(p => p.BookingDetails)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__Booking_D__servi__534D60F1");
        });

        modelBuilder.Entity<Combo>(entity =>
        {
            entity.HasKey(e => e.ComboId).HasName("PK__Combo__3C30C369B0BC9225");

            entity.ToTable("Combo");

            entity.Property(e => e.ComboId)
                .ValueGeneratedNever()
                .HasColumnName("comboID");
            entity.Property(e => e.ComboType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("comboType");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CusId).HasName("PK__Customer__BA9897D361CDA2E7");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.Id, "UQ_Customer_Id").IsUnique();

            entity.Property(e => e.CusId)
                .ValueGeneratedNever()
                .HasColumnName("cusID");
            entity.Property(e => e.AdminId).HasColumnName("adminID");
            entity.Property(e => e.CusRank)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cusRank");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Admin).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Admin");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_AspNetUsers");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoice__1252410C1622F1EA");

            entity.ToTable("Invoice");

            entity.Property(e => e.InvoiceId)
                .ValueGeneratedNever()
                .HasColumnName("invoiceID");
            entity.Property(e => e.BookingId).HasColumnName("bookingID");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");

            entity.HasOne(d => d.Booking).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoice__booking__5AEE82B9");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManaId).HasName("PK__Manager__22DAE4264DC65004");

            entity.ToTable("Manager");

            entity.HasIndex(e => e.Id, "UQ_Manager_Id").IsUnique();

            entity.Property(e => e.ManaId)
                .ValueGeneratedNever()
                .HasColumnName("manaID");
            entity.Property(e => e.AdminId).HasColumnName("adminID");
            entity.Property(e => e.BookingId).HasColumnName("bookingID");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Manager)
                .HasForeignKey<Manager>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Manager_AspNetUsers");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PayId).HasName("PK__Payment__082E8AE3B771F3B3");

            entity.ToTable("Payment");

            entity.Property(e => e.PayId)
                .ValueGeneratedNever()
                .HasColumnName("payID");
            entity.Property(e => e.InvoiceId).HasColumnName("invoiceID");

            entity.HasOne(d => d.Invoice).WithMany(p => p.Payments)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payment__invoice__5EBF139D");
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.PetId).HasName("PK__Pet__DDF85059445442CA");

            entity.ToTable("Pet");

            entity.Property(e => e.PetId)
                .ValueGeneratedNever()
                .HasColumnName("petID");
            entity.Property(e => e.CusId).HasColumnName("cusID");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.PetBirthday).HasColumnName("petBirthday");
            entity.Property(e => e.PetHeight)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("petHeight");
            entity.Property(e => e.PetName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("petName");
            entity.Property(e => e.PetType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("petType");
            entity.Property(e => e.PetWeight)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("petWeight");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Cus).WithMany(p => p.Pets)
                .HasForeignKey(d => d.CusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pet__cusID__47DBAE45");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__4550733F4C227307");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("serviceID");
            entity.Property(e => e.ComboId).HasColumnName("comboID");
            entity.Property(e => e.ServiceDescription)
                .HasColumnType("text")
                .HasColumnName("serviceDescription");
            entity.Property(e => e.ServiceImage).HasColumnName("serviceImage");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("serviceName");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Combo).WithMany(p => p.Services)
                .HasForeignKey(d => d.ComboId)
                .HasConstraintName("FK_Service_Combo");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__6465E19E05D526E9");

            entity.HasIndex(e => e.Id, "UQ_Staff_Id").IsUnique();

            entity.Property(e => e.StaffId)
                .ValueGeneratedNever()
                .HasColumnName("staffID");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Staff)
                .HasForeignKey<Staff>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Staff_AspNetUsers");

            entity.HasOne(d => d.ManagerMana).WithMany(p => p.Staff).HasForeignKey(d => d.ManagerManaId);
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.VoucherId).HasName("PK__Voucher__F53389899EBEA773");

            entity.ToTable("Voucher");

            entity.Property(e => e.VoucherId)
                .ValueGeneratedNever()
                .HasColumnName("voucherID");
            entity.Property(e => e.BookingId).HasColumnName("bookingID");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.CusId).HasColumnName("cusID");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.ExpiryDate).HasColumnName("expiryDate");
            entity.Property(e => e.IssueDate).HasColumnName("issueDate");
            entity.Property(e => e.ManaId).HasColumnName("manaID");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Booking).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Voucher__booking__6A30C649");

            entity.HasOne(d => d.Cus).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.CusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Voucher__cusID__68487DD7");

            entity.HasOne(d => d.Mana).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.ManaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Voucher__manaID__693CA210");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
