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
    [Migration("20190201124008_AddFolderColToProducts")]
    partial class AddFolderColToProducts
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

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool?>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired();

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
                        new { Id = 1, CreatedAt = new DateTime(2019, 2, 1, 12, 40, 7, 2, DateTimeKind.Utc), CreatedBy = "admin", Name = "وصفات الطعام", PredefinedKey = 2, ProfilePicture = "Files/Articles%20Categories/food.png" },
                        new { Id = 2, CreatedAt = new DateTime(2019, 2, 1, 12, 40, 7, 6, DateTimeKind.Utc), CreatedBy = "admin", Name = "الأخبار", PredefinedKey = 1, ProfilePicture = "Files/Articles%20Categories/news.png" }
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
                        new { Id = "244ad97b-a914-465a-926c-92df0c297bdc", Name = "Client" },
                        new { Id = "010721d6-1678-4dcf-b73b-bebf465c72c6", Name = "RegularUser" },
                        new { Id = "819f2549-7706-41df-8c8c-d455a360d310", Name = "Trainer" },
                        new { Id = "01efeabe-5f77-4629-afeb-99d990577feb", Name = "ArticleWriter" }
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
                        new { Id = "7c654344-ad42-4428-a77a-00a8c1299c3f", AccessFailedCount = 0, Email = "ahmedkabbash@gmail.com", EmailConfirmed = true, FullName = "ahmed kabbash", LockoutEnabled = false, PhoneNumberConfirmed = false, TwoFactorEnabled = false, UserName = "Admin" }
                    );
                });

            modelBuilder.Entity("Shared.Core.Models.Calories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(128);

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Calories");
                });

            modelBuilder.Entity("Shared.Core.Models.Championships", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Place")
                        .IsRequired();

                    b.Property<string>("ProfilePicture")
                        .IsRequired();

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Championships");
                });

            modelBuilder.Entity("Shared.Core.Models.Clients", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Shared.Core.Models.ClientsDocuments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnName("ClientID")
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Path")
                        .IsRequired();

                    b.Property<bool>("SentToClient");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Clients_Documents");
                });

            modelBuilder.Entity("Shared.Core.Models.ClientsImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Path")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Clients_Images");
                });

            modelBuilder.Entity("Shared.Core.Models.ClientsMeasurments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<byte>("TypeId");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(128);

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(8, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Clients_Measurments");
                });

            modelBuilder.Entity("Shared.Core.Models.ClientsOverloads", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<byte>("TypeId");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(128);

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(8, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Clients_Overloads");
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

                    b.HasIndex("EntityTypeId");

                    b.HasIndex("ItemsForReviewId");

                    b.ToTable("EntityRatings");
                });

            modelBuilder.Entity("Shared.Core.Models.EntityTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EntityTypes");

                    b.HasData(
                        new { Id = 1, Name = "product" },
                        new { Id = 4, Name = "hamda" },
                        new { Id = 9, Name = "m7maaa ma7rooos" }
                    );
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

            modelBuilder.Entity("Shared.Core.Models.Measurments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<byte>("TypeId");

                    b.HasKey("Id");

                    b.ToTable("Measurments");
                });

            modelBuilder.Entity("Shared.Core.Models.MigrationHistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasMaxLength(150);

                    b.Property<string>("ContextKey")
                        .HasMaxLength(300);

                    b.Property<byte[]>("Model")
                        .IsRequired();

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("MigrationId", "ContextKey");

                    b.ToTable("__MigrationHistory");
                });

            modelBuilder.Entity("Shared.Core.Models.Overloads", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<byte>("TypeId");

                    b.HasKey("Id");

                    b.ToTable("Overloads");
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

            modelBuilder.Entity("Shared.Core.Models.ProgramsImages", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Description");

                    b.Property<int>("ParentId");

                    b.Property<string>("Path")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Programs_Images");
                });

            modelBuilder.Entity("Shared.Core.Models.ProgramsPrices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("ProgramId");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.ToTable("Programs_Prices");
                });

            modelBuilder.Entity("Shared.Core.Models.Trainers", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128);

                    b.Property<string>("Bio")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("Shared.Core.Models.TrainersPrograms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("ProfilePicture")
                        .IsRequired();

                    b.Property<string>("TrainerId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("TrainerId");

                    b.ToTable("Trainers_Programs");
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

            modelBuilder.Entity("Shared.Core.Models.Clients", b =>
                {
                    b.HasOne("Shared.Core.Models.AspNetUsers", "IdNavigation")
                        .WithOne("Clients")
                        .HasForeignKey("Shared.Core.Models.Clients", "Id")
                        .HasConstraintName("FK_Clients_dbo.AspNetUsers")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shared.Core.Models.ClientsDocuments", b =>
                {
                    b.HasOne("Shared.Core.Models.Clients", "Client")
                        .WithMany("ClientsDocuments")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK_Clients_Documents_Clients");
                });

            modelBuilder.Entity("Shared.Core.Models.ClientsImages", b =>
                {
                    b.HasOne("Shared.Core.Models.Clients", "Client")
                        .WithMany("ClientsImages")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK_Clients_Images_Clients");
                });

            modelBuilder.Entity("Shared.Core.Models.ClientsMeasurments", b =>
                {
                    b.HasOne("Shared.Core.Models.Clients", "Client")
                        .WithMany("ClientsMeasurments")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK_Clients_Measurments_Clients");
                });

            modelBuilder.Entity("Shared.Core.Models.ClientsOverloads", b =>
                {
                    b.HasOne("Shared.Core.Models.Clients", "Client")
                        .WithMany("ClientsOverloads")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK_Clients_Overloads_Clients");
                });

            modelBuilder.Entity("Shared.Core.Models.EntityRating", b =>
                {
                    b.HasOne("Shared.Core.Models.AspNetUsers", "Reviwer")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Shared.Core.Models.EntityTypes", "EntityType")
                        .WithMany()
                        .HasForeignKey("EntityTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shared.Core.Models.ItemsForReview")
                        .WithMany("Reviews")
                        .HasForeignKey("ItemsForReviewId");
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
                        .WithMany("ProductsImages")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("FK_Products_Images_Products");
                });

            modelBuilder.Entity("Shared.Core.Models.ProgramsImages", b =>
                {
                    b.HasOne("Shared.Core.Models.TrainersPrograms", "Program")
                        .WithMany("ProgramsImages")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("FK_Programs_Images_Trainers_Programs");
                });

            modelBuilder.Entity("Shared.Core.Models.ProgramsPrices", b =>
                {
                    b.HasOne("Shared.Core.Models.TrainersPrograms", "Program")
                        .WithMany("ProgramsPrices")
                        .HasForeignKey("ProgramId")
                        .HasConstraintName("FK_Programs_Prices_Trainers_Programs");
                });

            modelBuilder.Entity("Shared.Core.Models.Trainers", b =>
                {
                    b.HasOne("Shared.Core.Models.AspNetUsers", "IdNavigation")
                        .WithOne("Trainers")
                        .HasForeignKey("Shared.Core.Models.Trainers", "Id")
                        .HasConstraintName("FK_Trainers_dbo_AspNetUsers")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shared.Core.Models.TrainersPrograms", b =>
                {
                    b.HasOne("Shared.Core.Models.Trainers", "Trainer")
                        .WithMany("TrainersPrograms")
                        .HasForeignKey("TrainerId")
                        .HasConstraintName("FK_Trainers_Programs_Trainers");
                });
#pragma warning restore 612, 618
        }
    }
}
