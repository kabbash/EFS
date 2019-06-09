﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trainer.EF;

namespace Trainer.EF.Migrations
{
    [DbContext(typeof(EFSContext))]
    partial class EFSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shared.Core.Models.Articles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool?>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Place");

                    b.Property<string>("ProfilePicture")
                        .IsRequired();

                    b.Property<string>("RejectReason");

                    b.Property<string>("SubFolderName");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Shared.Core.Models.ArticlesCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("PredefinedKey");

                    b.Property<string>("ProfilePicture")
                        .IsRequired();

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Articles_Categories");

                    b.HasData(
                        new { Id = 1, CreatedAt = new DateTime(2019, 6, 6, 3, 22, 54, 884, DateTimeKind.Utc), CreatedBy = "admin", Name = "وصفات الطعام", PredefinedKey = 2, ProfilePicture = "Files/Articles%20Categories/food.png" },
                        new { Id = 2, CreatedAt = new DateTime(2019, 6, 6, 3, 22, 54, 898, DateTimeKind.Utc), CreatedBy = "admin", Name = "الأخبار", PredefinedKey = 1, ProfilePicture = "Files/Articles%20Categories/news.png" },
                        new { Id = 3, CreatedAt = new DateTime(2019, 6, 6, 3, 22, 54, 898, DateTimeKind.Utc), CreatedBy = "admin", Name = "البطولات", PredefinedKey = 3, ProfilePicture = "Files/Articles%20Categories/championships.png" }
                    );
                });

            modelBuilder.Entity("Shared.Core.Models.ArticlesImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("ParentId");

                    b.Property<string>("Path")
                        .IsRequired();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("ArticlesImages");
                });

            modelBuilder.Entity("Shared.Core.Models.AspNetRoles", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new { Id = "1d2b6cf6-8e86-46e9-9df2-2cdfc8f906f3", Name = "Admin" },
                        new { Id = "07ab2dd0-83e1-49a4-a8dc-66d948355392", Name = "Regular User" },
                        new { Id = "6a883f63-ef24-4693-a10f-ac30aaca972e", Name = "Articles Writer" }
                    );
                });

            modelBuilder.Entity("Shared.Core.Models.AspNetUserClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Shared.Core.Models.AspNetUserLogins", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("UserId")
                        .HasMaxLength(128);

                    b.HasKey("LoginProvider", "ProviderKey", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Shared.Core.Models.AspNetUserRoles", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(128);

                    b.Property<string>("RoleId")
                        .HasMaxLength(128);

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new { UserId = "7c654344-ad42-4428-a77a-00a8c1299c3f", RoleId = "1d2b6cf6-8e86-46e9-9df2-2cdfc8f906f3" },
                        new { UserId = "948f5fb5-00ce-4d61-9e4b-741290e20024", RoleId = "6a883f63-ef24-4693-a10f-ac30aaca972e" },
                        new { UserId = "b62f98ba-68ea-45d0-8209-48ee24d40e53", RoleId = "07ab2dd0-83e1-49a4-a8dc-66d948355392" }
                    );
                });

            modelBuilder.Entity("Shared.Core.Models.AspNetUsers", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FacebookId");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Hometown");

                    b.Property<bool>("IsBlocked");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTime?>("LockoutEndDateUtc")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProfilePicture");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new { Id = "7c654344-ad42-4428-a77a-00a8c1299c3f", AccessFailedCount = 0, Email = "admin@efs.com", EmailConfirmed = true, FullName = "admin", IsBlocked = false, LockoutEnabled = false, PasswordHash = new byte[] { 42, 239, 163, 106, 200, 213, 171, 17, 175, 247, 159, 124, 176, 38, 57, 220, 225, 58, 10, 123, 36, 48, 38, 145, 61, 220, 53, 83, 107, 47, 213, 122, 219, 191, 185, 32, 178, 250, 203, 32, 237, 35, 212, 5, 131, 117, 18, 106, 72, 219, 32, 189, 215, 71, 240, 218, 178, 66, 48, 24, 228, 220, 234, 69 }, PasswordSalt = new byte[] { 44, 106, 207, 208, 221, 217, 115, 182, 175, 97, 6, 242, 76, 200, 68, 212, 114, 212, 54, 102, 100, 219, 189, 82, 241, 36, 186, 68, 248, 8, 5, 177, 165, 186, 206, 109, 168, 201, 28, 233, 180, 27, 68, 156, 214, 118, 93, 77, 30, 79, 106, 98, 4, 117, 153, 80, 212, 118, 102, 206, 16, 229, 144, 127, 69, 49, 221, 206, 249, 229, 230, 84, 74, 178, 185, 85, 59, 117, 106, 117, 23, 34, 137, 216, 81, 67, 241, 16, 130, 38, 17, 67, 42, 152, 238, 10, 198, 179, 159, 156, 175, 111, 76, 220, 31, 36, 206, 208, 127, 121, 0, 178, 140, 41, 177, 74, 202, 188, 82, 213, 60, 246, 243, 54, 177, 155, 10, 241 }, PhoneNumber = "01012345678", PhoneNumberConfirmed = false, TwoFactorEnabled = false, UserName = "admin@efs.com" },
                        new { Id = "948f5fb5-00ce-4d61-9e4b-741290e20024", AccessFailedCount = 0, Email = "writer@efs.com", EmailConfirmed = true, FullName = "articles writer", IsBlocked = false, LockoutEnabled = false, PasswordHash = new byte[] { 42, 239, 163, 106, 200, 213, 171, 17, 175, 247, 159, 124, 176, 38, 57, 220, 225, 58, 10, 123, 36, 48, 38, 145, 61, 220, 53, 83, 107, 47, 213, 122, 219, 191, 185, 32, 178, 250, 203, 32, 237, 35, 212, 5, 131, 117, 18, 106, 72, 219, 32, 189, 215, 71, 240, 218, 178, 66, 48, 24, 228, 220, 234, 69 }, PasswordSalt = new byte[] { 44, 106, 207, 208, 221, 217, 115, 182, 175, 97, 6, 242, 76, 200, 68, 212, 114, 212, 54, 102, 100, 219, 189, 82, 241, 36, 186, 68, 248, 8, 5, 177, 165, 186, 206, 109, 168, 201, 28, 233, 180, 27, 68, 156, 214, 118, 93, 77, 30, 79, 106, 98, 4, 117, 153, 80, 212, 118, 102, 206, 16, 229, 144, 127, 69, 49, 221, 206, 249, 229, 230, 84, 74, 178, 185, 85, 59, 117, 106, 117, 23, 34, 137, 216, 81, 67, 241, 16, 130, 38, 17, 67, 42, 152, 238, 10, 198, 179, 159, 156, 175, 111, 76, 220, 31, 36, 206, 208, 127, 121, 0, 178, 140, 41, 177, 74, 202, 188, 82, 213, 60, 246, 243, 54, 177, 155, 10, 241 }, PhoneNumber = "01012345678", PhoneNumberConfirmed = false, TwoFactorEnabled = false, UserName = "writer@gmail.com" },
                        new { Id = "b62f98ba-68ea-45d0-8209-48ee24d40e53", AccessFailedCount = 0, Email = "user@efs.com", EmailConfirmed = true, FullName = "regular user", IsBlocked = false, LockoutEnabled = false, PasswordHash = new byte[] { 42, 239, 163, 106, 200, 213, 171, 17, 175, 247, 159, 124, 176, 38, 57, 220, 225, 58, 10, 123, 36, 48, 38, 145, 61, 220, 53, 83, 107, 47, 213, 122, 219, 191, 185, 32, 178, 250, 203, 32, 237, 35, 212, 5, 131, 117, 18, 106, 72, 219, 32, 189, 215, 71, 240, 218, 178, 66, 48, 24, 228, 220, 234, 69 }, PasswordSalt = new byte[] { 44, 106, 207, 208, 221, 217, 115, 182, 175, 97, 6, 242, 76, 200, 68, 212, 114, 212, 54, 102, 100, 219, 189, 82, 241, 36, 186, 68, 248, 8, 5, 177, 165, 186, 206, 109, 168, 201, 28, 233, 180, 27, 68, 156, 214, 118, 93, 77, 30, 79, 106, 98, 4, 117, 153, 80, 212, 118, 102, 206, 16, 229, 144, 127, 69, 49, 221, 206, 249, 229, 230, 84, 74, 178, 185, 85, 59, 117, 106, 117, 23, 34, 137, 216, 81, 67, 241, 16, 130, 38, 17, 67, 42, 152, 238, 10, 198, 179, 159, 156, 175, 111, 76, 220, 31, 36, 206, 208, 127, 121, 0, 178, 140, 41, 177, 74, 202, 188, 82, 213, 60, 246, 243, 54, 177, 155, 10, 241 }, PhoneNumber = "01012345678", PhoneNumberConfirmed = false, TwoFactorEnabled = false, UserName = "user@efs.com" }
                    );
                });

            modelBuilder.Entity("Shared.Core.Models.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ButtonText");

                    b.Property<string>("ButtonUrl");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("ImagePath")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("Shared.Core.Models.Configurations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Type");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("Shared.Core.Models.EntityRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<int>("EntityId");

                    b.Property<int>("EntityTypeId");

                    b.Property<int?>("ItemsForReviewId");

                    b.Property<int>("Rate");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ItemsForReviewId");

                    b.ToTable("EntityRatings");
                });

            modelBuilder.Entity("Shared.Core.Models.FoodItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Alcohol");

                    b.Property<decimal>("Amount");

                    b.Property<decimal>("B1");

                    b.Property<decimal>("B12");

                    b.Property<decimal>("B2");

                    b.Property<decimal>("B3");

                    b.Property<decimal>("B5");

                    b.Property<decimal>("B6");

                    b.Property<decimal>("Caffiene");

                    b.Property<decimal>("Calcuim");

                    b.Property<decimal>("Calories");

                    b.Property<decimal>("Carbs");

                    b.Property<decimal>("Cholesterol");

                    b.Property<decimal>("Copper");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<decimal>("Cystine");

                    b.Property<decimal>("Energy");

                    b.Property<decimal>("Fat");

                    b.Property<decimal>("Fiber");

                    b.Property<decimal>("Folate");

                    b.Property<decimal>("Histidine");

                    b.Property<decimal>("Iron");

                    b.Property<decimal>("Isoleucine");

                    b.Property<decimal>("Leucine");

                    b.Property<decimal>("Lysine");

                    b.Property<decimal>("Magnesium");

                    b.Property<decimal>("Manganese");

                    b.Property<decimal>("Methionine");

                    b.Property<decimal>("Monounsaturated");

                    b.Property<string>("Name");

                    b.Property<decimal>("NetCarbs");

                    b.Property<decimal>("Omega3");

                    b.Property<decimal>("Omega6");

                    b.Property<decimal>("Phenylalanine");

                    b.Property<decimal>("Phosphorus");

                    b.Property<decimal>("Polyunsaturated");

                    b.Property<decimal>("Potassium");

                    b.Property<decimal>("Protein");

                    b.Property<decimal>("Saturated");

                    b.Property<decimal>("Selenium");

                    b.Property<decimal>("Sodium");

                    b.Property<decimal>("Starch");

                    b.Property<decimal>("Sugars");

                    b.Property<decimal>("Threonine");

                    b.Property<decimal>("TransFats");

                    b.Property<decimal>("Tryptophan");

                    b.Property<decimal>("Tyrosine");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.Property<decimal>("Valine");

                    b.Property<decimal>("VitaminA");

                    b.Property<decimal>("VitaminC");

                    b.Property<decimal>("VitaminD");

                    b.Property<decimal>("VitaminE");

                    b.Property<decimal>("VitaminK");

                    b.Property<decimal>("Water");

                    b.Property<decimal>("Zinc");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("FoodItems");
                });

            modelBuilder.Entity("Shared.Core.Models.ItemsForReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("ProfilePicture");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("ItemsForReviews");
                });

            modelBuilder.Entity("Shared.Core.Models.OTrainingPrograms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Features");

                    b.Property<string>("Name");

                    b.Property<string>("ProfilePicture");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("OTrainingPrograms");
                });

            modelBuilder.Entity("Shared.Core.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Description");

                    b.Property<DateTime?>("ExpDate")
                        .HasColumnType("date");

                    b.Property<bool?>("IsActive");

                    b.Property<bool>("IsSpecial");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PhoneNumber");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("ProfilePicture")
                        .IsRequired();

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("RejectReason");

                    b.Property<string>("SubFolderName");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Shared.Core.Models.ProductsCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("ParentId");

                    b.Property<string>("ProfilePicture");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Products_Categories");
                });

            modelBuilder.Entity("Shared.Core.Models.ProductsImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ParentId");

                    b.Property<string>("Path")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Products_Images");
                });

            modelBuilder.Entity("Shared.Core.Models.Articles", b =>
                {
                    b.HasOne("Shared.Core.Models.ArticlesCategories", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Articles_Articles_Categories");

                    b.HasOne("Shared.Core.Models.AspNetUsers", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shared.Core.Models.ArticlesImages", b =>
                {
                    b.HasOne("Shared.Core.Models.Articles", "Article")
                        .WithMany("Images")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shared.Core.Models.AspNetUserClaims", b =>
                {
                    b.HasOne("Shared.Core.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shared.Core.Models.AspNetUserLogins", b =>
                {
                    b.HasOne("Shared.Core.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shared.Core.Models.AspNetUserRoles", b =>
                {
                    b.HasOne("Shared.Core.Models.AspNetRoles", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shared.Core.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shared.Core.Models.EntityRating", b =>
                {
                    b.HasOne("Shared.Core.Models.AspNetUsers", "Reviwer")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Shared.Core.Models.ItemsForReview")
                        .WithMany("Reviews")
                        .HasForeignKey("ItemsForReviewId");
                });

            modelBuilder.Entity("Shared.Core.Models.FoodItem", b =>
                {
                    b.HasOne("Shared.Core.Models.AspNetUsers", "Author")
                        .WithMany()
                        .HasForeignKey("CreatedBy");
                });

            modelBuilder.Entity("Shared.Core.Models.Products", b =>
                {
                    b.HasOne("Shared.Core.Models.ProductsCategories", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Products_Products_Subcategories")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shared.Core.Models.AspNetUsers", "Seller")
                        .WithMany("Products")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("FK_Products_AspNetUsers_CreatedBy");
                });

            modelBuilder.Entity("Shared.Core.Models.ProductsCategories", b =>
                {
                    b.HasOne("Shared.Core.Models.ProductsCategories")
                        .WithMany("Subcategories")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Shared.Core.Models.ProductsImages", b =>
                {
                    b.HasOne("Shared.Core.Models.Products", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("FK_Products_Images_Products")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
