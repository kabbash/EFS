using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Trainer.Models
{
    public partial class EFS_DevContext : DbContext
    {
        public EFS_DevContext()
        {
        }

        public EFS_DevContext(DbContextOptions<EFS_DevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<ArticlesCategories> ArticlesCategories { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Calories> Calories { get; set; }
        public virtual DbSet<Championships> Championships { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<ClientsDocuments> ClientsDocuments { get; set; }
        public virtual DbSet<ClientsImages> ClientsImages { get; set; }
        public virtual DbSet<ClientsMeasurments> ClientsMeasurments { get; set; }
        public virtual DbSet<ClientsOverloads> ClientsOverloads { get; set; }
        public virtual DbSet<Measurments> Measurments { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Overloads> Overloads { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsCategories> ProductsCategories { get; set; }
        public virtual DbSet<ProductsImages> ProductsImages { get; set; }
        public virtual DbSet<ProductsOwners> ProductsOwners { get; set; }
        public virtual DbSet<ProductsSubcategories> ProductsSubcategories { get; set; }
        public virtual DbSet<ProgramsImages> ProgramsImages { get; set; }
        public virtual DbSet<ProgramsPrices> ProgramsPrices { get; set; }
        public virtual DbSet<Trainers> Trainers { get; set; }
        public virtual DbSet<TrainersPrograms> TrainersPrograms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-55PE9HK\\MOHAMEDMAGDY;Database=EFS_Dev;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articles>(entity =>
            {
                entity.Property(e => e.AuthorId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(128);

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.ProfilePicture).IsRequired();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Articles_AspNetUsers");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Articles_Articles_Categories");
            });

            modelBuilder.Entity<ArticlesCategories>(entity =>
            {
                entity.ToTable("Articles_Categories");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProfilePicture).IsRequired();
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.AspNetUsers)
                    .HasForeignKey<AspNetUsers>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetUsers_Clients");

                entity.HasOne(d => d.Id1)
                    .WithOne(p => p.AspNetUsers)
                    .HasForeignKey<AspNetUsers>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetUsers_Products_Owners");

                entity.HasOne(d => d.Id2)
                    .WithOne(p => p.AspNetUsers)
                    .HasForeignKey<AspNetUsers>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetUsers_Trainers");
            });

            modelBuilder.Entity<Calories>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Value).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Championships>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(128);

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Place).IsRequired();

                entity.Property(e => e.ProfilePicture).IsRequired();
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<ClientsDocuments>(entity =>
            {
                entity.ToTable("Clients_Documents");

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasColumnName("ClientID")
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Path).IsRequired();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientsDocuments)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clients_Documents_Clients");
            });

            modelBuilder.Entity<ClientsImages>(entity =>
            {
                entity.ToTable("Clients_Images");

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Path).IsRequired();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientsImages)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clients_Images_Clients");
            });

            modelBuilder.Entity<ClientsMeasurments>(entity =>
            {
                entity.ToTable("Clients_Measurments");

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Value).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientsMeasurments)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clients_Measurments_Clients");
            });

            modelBuilder.Entity<ClientsOverloads>(entity =>
            {
                entity.ToTable("Clients_Overloads");

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Value).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientsOverloads)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clients_Overloads_Clients");
            });

            modelBuilder.Entity<Measurments>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Overloads>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ExpDate).HasColumnType("date");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OwnerId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProdDate).HasColumnType("date");

                entity.Property(e => e.ProfilePicture).IsRequired();

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Products_Owners");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SubcategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Products_Subcategories");
            });

            modelBuilder.Entity<ProductsCategories>(entity =>
            {
                entity.ToTable("Products_Categories");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ProductsImages>(entity =>
            {
                entity.ToTable("Products_Images");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Path).IsRequired();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsImages)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Images_Products");
            });

            modelBuilder.Entity<ProductsOwners>(entity =>
            {
                entity.ToTable("Products_Owners");

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.ContactInfo).IsRequired();
            });

            modelBuilder.Entity<ProductsSubcategories>(entity =>
            {
                entity.ToTable("Products_Subcategories");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductsSubcategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Subcategories_Products_Categories");
            });

            modelBuilder.Entity<ProgramsImages>(entity =>
            {
                entity.ToTable("Programs_Images");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Path).IsRequired();

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.ProgramsImages)
                    .HasForeignKey(d => d.ProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Programs_Images_Trainers_Programs");
            });

            modelBuilder.Entity<ProgramsPrices>(entity =>
            {
                entity.ToTable("Programs_Prices");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Duration)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.ProgramsPrices)
                    .HasForeignKey(d => d.ProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Programs_Prices_Trainers_Programs");
            });

            modelBuilder.Entity<Trainers>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Bio).IsRequired();
            });

            modelBuilder.Entity<TrainersPrograms>(entity =>
            {
                entity.ToTable("Trainers_Programs");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ProfilePicture).IsRequired();

                entity.Property(e => e.TrainerId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.TrainersPrograms)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trainers_Programs_Trainers");
            });
        }
    }
}
