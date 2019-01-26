using Microsoft.EntityFrameworkCore;
using Shared.Core.Models;
using System;

namespace Trainer.EF
{
    public partial class EFSContext : DbContext
    {
        public EFSContext()
        {
        }

        public EFSContext(DbContextOptions<EFSContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<ArticlesImages> ArticlesImages { get; set; }
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
        public virtual DbSet<ProgramsImages> ProgramsImages { get; set; }
        public virtual DbSet<ProgramsPrices> ProgramsPrices { get; set; }
        public virtual DbSet<Trainers> Trainers { get; set; }
        public virtual DbSet<TrainersPrograms> TrainersPrograms { get; set; }
        public virtual DbSet<EntityRating> EntityRatings { get; set; }
        public virtual DbSet<EntityTypes> EntityTypes { get; set; }
        public virtual DbSet<ItemsForReview> ItemsForReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articles>(entity =>
            {
                entity.HasIndex(e => e.CategoryId);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.ProfilePicture).IsRequired();

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Articles_Articles_Categories");
            });

            modelBuilder.Entity<ArticlesCategories>(entity =>
            {
                entity.ToTable("Articles_Categories");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProfilePicture).IsRequired();

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);
                entity.HasData(new ArticlesCategories[]
                {
                    new ArticlesCategories {Id= 1 , Name = "وصفات الطعام" , PredefinedKey= 2, CreatedAt= DateTime.Now.ToUniversalTime(), CreatedBy= "admin", ProfilePicture="Files/Articles%20Categories/food.png"},
                    new ArticlesCategories {Id=2, Name = "الأخبار" , PredefinedKey= 1, CreatedAt= DateTime.Now.ToUniversalTime(), CreatedBy= "admin", ProfilePicture="Files/Articles%20Categories/news.png"}

                });
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
                entity.HasData(new AspNetRoles[] {
                    new AspNetRoles { Id = "1d2b6cf6-8e86-46e9-9df2-2cdfc8f906f3", Name = "Admin"},
                    new AspNetRoles { Id = Guid.NewGuid().ToString(), Name = "Client"},
                    new AspNetRoles { Id = Guid.NewGuid().ToString(), Name = "RegularUser"},
                    new AspNetRoles { Id = Guid.NewGuid().ToString(), Name = "Trainer"},
                    new AspNetRoles { Id = Guid.NewGuid().ToString(), Name = "ArticleWriter"}
                }
                    );
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

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

                entity.HasIndex(e => e.UserId);

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

                entity.HasIndex(e => e.RoleId);

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
                entity.HasData(new AspNetUserRoles
                {
                    RoleId = "1d2b6cf6-8e86-46e9-9df2-2cdfc8f906f3",
                    UserId = "7c654344-ad42-4428-a77a-00a8c1299c3f"
                });
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                //entity.Property(e => e.LastName)
                //    .IsRequired()
                //    .HasMaxLength(50);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
                entity.HasIndex(e => e.UserName).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasData(new AspNetUsers
                {
                    Id = "7c654344-ad42-4428-a77a-00a8c1299c3f",
                    Email = "ahmedkabbash@gmail.com",
                    EmailConfirmed = true,
                    FullName = "ahmed kabbash",
                    //LastName = "kabbash",
                    UserName = "Admin"
                    //PasswordHash = "1234",

                });
            });

            modelBuilder.Entity<Calories>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

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

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Place).IsRequired();

                entity.Property(e => e.ProfilePicture).IsRequired();

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Clients)
                    .HasForeignKey<Clients>(d => d.Id)
                    .HasConstraintName("FK_Clients_dbo.AspNetUsers");
            });

            modelBuilder.Entity<ClientsDocuments>(entity =>
            {
                entity.ToTable("Clients_Documents");

                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasColumnName("ClientID")
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

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

                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Title)
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

                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

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

                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

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
                entity.HasIndex(e => e.CategoryId);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ExpDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProfilePicture).IsRequired();

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Products_Products_Subcategories");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_AspNetUsers_CreatedBy");
            });

            modelBuilder.Entity<ProductsCategories>(entity =>
            {
                entity.ToTable("Products_Categories");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);
            });

            modelBuilder.Entity<ProductsImages>(entity =>
            {
                entity.ToTable("Products_Images");

                entity.HasIndex(e => e.ParentId);

                entity.Property(e => e.Path).IsRequired();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsImages)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Images_Products");
            });

            modelBuilder.Entity<ProgramsImages>(entity =>
            {
                entity.ToTable("Programs_Images");

                entity.HasIndex(e => e.ParentId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Path).IsRequired();

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.ProgramsImages)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Programs_Images_Trainers_Programs");
            });

            modelBuilder.Entity<ProgramsPrices>(entity =>
            {
                entity.ToTable("Programs_Prices");

                entity.HasIndex(e => e.ProgramId);

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

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Trainers)
                    .HasForeignKey<Trainers>(d => d.Id)
                    .HasConstraintName("FK_Trainers_dbo_AspNetUsers");
            });

            modelBuilder.Entity<TrainersPrograms>(entity =>
            {
                entity.ToTable("Trainers_Programs");

                entity.HasIndex(e => e.TrainerId);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ProfilePicture).IsRequired();

                entity.Property(e => e.TrainerId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.TrainersPrograms)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trainers_Programs_Trainers");
            });

            modelBuilder.Entity<EntityTypes>(entity =>
            {
                entity.HasData(new EntityTypes
                {
                    Id = 1,
                    Name = "product"
                });
                entity.HasData(new EntityTypes
                {
                    Id = 4,
                    Name = "hamda"
                });
                entity.HasData(new EntityTypes
                {
                    Id = 9,
                    Name = "m7maaa ma7rooos"
                });
            });
        }
    }
}
