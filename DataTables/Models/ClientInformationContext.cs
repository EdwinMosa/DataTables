using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataTables.Models
{
    public partial class ClientInformationContext : DbContext
    {
        public ClientInformationContext()
        {
        }

        public ClientInformationContext(DbContextOptions<ClientInformationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAddress> TblAddresses { get; set; }
        public virtual DbSet<TblAddressType> TblAddressTypes { get; set; }
        public virtual DbSet<TblClient> TblClients { get; set; }
        public virtual DbSet<TblContact> TblContacts { get; set; }
        public virtual DbSet<TblContactType> TblContactTypes { get; set; }
        public virtual DbSet<TblCountry> TblCountries { get; set; }
        public virtual DbSet<TblGender> TblGenders { get; set; }
        public virtual DbSet<VClient> VClients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ClientInformation;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<TblAddress>(entity =>
            {
                entity.ToTable("tbl_Address");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AddressTypeId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("AddressTypeID");

                entity.Property(e => e.ClientId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ClientID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TblAddresses)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Address_tbl_Client");
            });

            modelBuilder.Entity<TblAddressType>(entity =>
            {
                entity.ToTable("tbl_AddressType");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblClient>(entity =>
            {
                entity.ToTable("tbl_Client");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CountryId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CountryID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.GenderId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("GenderID");

                entity.Property(e => e.Idnumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IDNumber");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblContact>(entity =>
            {
                entity.ToTable("tbl_Contact");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ClientId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ClientID");

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactTypeId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ContactTypeID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TblContacts)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Contact_tbl_Client");
            });

            modelBuilder.Entity<TblContactType>(entity =>
            {
                entity.ToTable("tbl_ContactType");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCountry>(entity =>
            {
                entity.ToTable("tbl_Country");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblGender>(entity =>
            {
                entity.ToTable("tbl_Gender");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VClient>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_Client");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CountryID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GenderId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("GenderID");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ID");

                entity.Property(e => e.Idnumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IDNumber");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
