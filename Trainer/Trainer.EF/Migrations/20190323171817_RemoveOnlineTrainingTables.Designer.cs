﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trainer.EF;

namespace Trainer.EF.Migrations
{
    [DbContext(typeof(EFSContext))]
    [Migration("20190323171817_RemoveOnlineTrainingTables")]
    partial class RemoveOnlineTrainingTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        new { Id = 1, CreatedAt = new DateTime(2019, 3, 23, 17, 18, 11, 765, DateTimeKind.Utc), CreatedBy = "admin", Name = "وصفات الطعام", PredefinedKey = 2, ProfilePicture = "Files/Articles%20Categories/food.png" },
                        new { Id = 2, CreatedAt = new DateTime(2019, 3, 23, 17, 18, 11, 773, DateTimeKind.Utc), CreatedBy = "admin", Name = "الأخبار", PredefinedKey = 1, ProfilePicture = "Files/Articles%20Categories/news.png" },
                        new { Id = 3, CreatedAt = new DateTime(2019, 3, 23, 17, 18, 11, 773, DateTimeKind.Utc), CreatedBy = "admin", Name = "البطولات", PredefinedKey = 3, ProfilePicture = "Files/Articles%20Categories/championships.png" }
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
                        new { Id = "b3c0d399-61f6-47e1-99eb-c545052992d6", Name = "Trainee" },
                        new { Id = "07ab2dd0-83e1-49a4-a8dc-66d948355392", Name = "Regular User" },
                        new { Id = "7c433dc0-d62b-43da-91d5-5b63e41a902f", Name = "Food Articles Writer" },
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
                        new { UserId = "7c654344-ad42-4428-a77a-00a8c1299c3f", RoleId = "1d2b6cf6-8e86-46e9-9df2-2cdfc8f906f3" }
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
                        new { Id = "7c654344-ad42-4428-a77a-00a8c1299c3f", AccessFailedCount = 0, Email = "ahmedkabbash@gmail.com", EmailConfirmed = true, FullName = "ahmed kabbash", IsBlocked = false, LockoutEnabled = false, PasswordHash = new byte[] { 191, 201, 142, 127, 18, 78, 68, 77, 213, 242, 72, 185, 25, 201, 71, 81, 127, 62, 234, 91, 61, 73, 16, 244, 208, 16, 6, 14, 162, 9, 78, 131, 63, 152, 51, 236, 173, 100, 128, 221, 177, 176, 82, 125, 187, 232, 224, 137, 70, 96, 39, 238, 236, 198, 136, 174, 145, 42, 212, 17, 93, 208, 248, 223 }, PasswordSalt = new byte[] { 124, 246, 219, 2, 238, 220, 175, 172, 150, 185, 111, 40, 253, 184, 180, 200, 242, 58, 2, 102, 203, 69, 7, 121, 158, 134, 171, 11, 237, 245, 163, 154, 175, 48, 149, 150, 139, 238, 93, 218, 245, 209, 101, 138, 175, 157, 211, 246, 182, 168, 151, 6, 46, 108, 160, 214, 180, 211, 114, 147, 4, 78, 12, 179, 182, 111, 171, 55, 229, 26, 105, 226, 128, 130, 50, 220, 234, 104, 223, 237, 30, 105, 127, 51, 42, 207, 233, 10, 99, 133, 17, 242, 98, 3, 183, 199, 31, 227, 107, 8, 23, 55, 87, 180, 105, 45, 33, 252, 11, 196, 126, 5, 75, 29, 242, 231, 221, 195, 115, 204, 125, 69, 134, 189, 201, 223, 73, 166 }, PhoneNumber = "01014991554", PhoneNumberConfirmed = false, TwoFactorEnabled = false, UserName = "ahmedkabbash@gmail.com" }
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