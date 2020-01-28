using Microsoft.EntityFrameworkCore;
using Shared.Core.Models;
using System;

namespace Trainer.EF
{
    public partial class EFSContext : DbContext
    {
        private readonly System.Security.Cryptography.HMACSHA512 hmac;
        
        public EFSContext()
        {
        }

        public EFSContext(DbContextOptions<EFSContext> options)
            : base(options)
        {
            hmac = new System.Security.Cryptography.HMACSHA512();
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
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsCategories> ProductsCategories { get; set; }
        public virtual DbSet<ProductsImages> ProductsImages { get; set; }
        public virtual DbSet<EntityRating> EntityRatings { get; set; }
        public virtual DbSet<ItemsForReview> ItemsForReviews { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<FoodItem> FoodItems { get; set; }
        public virtual DbSet<OTrainingPrograms> OTrainingPrograms { get; set; }
        public virtual DbSet<Configurations> Configurations { get; set; }
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
                    new ArticlesCategories {Id=2, Name = "الأخبار" , PredefinedKey= 1, CreatedAt= DateTime.Now.ToUniversalTime(), CreatedBy= "admin", ProfilePicture="Files/Articles%20Categories/news.png"},
                    new ArticlesCategories {Id=3, Name = "البطولات" , PredefinedKey= 3, CreatedAt= DateTime.Now.ToUniversalTime(), CreatedBy= "admin", ProfilePicture="Files/Articles%20Categories/championships.png"}


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
                    new AspNetRoles { Id = "07ab2dd0-83e1-49a4-a8dc-66d948355392", Name = "Regular User"},
                    new AspNetRoles { Id = "6a883f63-ef24-4693-a10f-ac30aaca972e", Name = "Articles Writer"}
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
                entity.HasData(new AspNetUserRoles[] {
                    new AspNetUserRoles {
                        RoleId = "1d2b6cf6-8e86-46e9-9df2-2cdfc8f906f3",
                        UserId = "7c654344-ad42-4428-a77a-00a8c1299c3f"
                    },
                    new AspNetUserRoles {
                        RoleId = "6a883f63-ef24-4693-a10f-ac30aaca972e",
                        UserId = "948f5fb5-00ce-4d61-9e4b-741290e20024"
                    },
                    new AspNetUserRoles {
                        RoleId = "07ab2dd0-83e1-49a4-a8dc-66d948355392",
                        UserId = "b62f98ba-68ea-45d0-8209-48ee24d40e53"
                    }
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
                entity.HasData(new AspNetUsers[] {
                    new AspNetUsers {
                        Id = "7c654344-ad42-4428-a77a-00a8c1299c3f",
                        Email = "admin@efs.com",
                        EmailConfirmed = true,
                        FullName = "admin",
                        UserName = "admin@efs.com",
                        PasswordSalt = hmac.Key,
                        PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("sJr$YK8jf@")),
                        PhoneNumber = "01097976064"

                    },
                    new AspNetUsers {
                        Id = "948f5fb5-00ce-4d61-9e4b-741290e20024",
                        Email = "writer@efs.com",
                        EmailConfirmed = true,
                        FullName = "articles writer",
                        UserName = "writer@gmail.com",
                        PasswordSalt = hmac.Key,
                        PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("1234")),
                        PhoneNumber = "01012345678"

                    },
                    new AspNetUsers {
                        Id = "b62f98ba-68ea-45d0-8209-48ee24d40e53",
                        Email = "user@efs.com",
                        EmailConfirmed = true,
                        FullName = "regular user",
                        UserName = "user@efs.com",
                        PasswordSalt = hmac.Key,
                        PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("1234")),
                        PhoneNumber = "01012345678"

                    }
                });
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
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Products_Images_Products");
            });           
        }
    }
}
