﻿// <auto-generated />
using System;
using MAJServices.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MAJServices.Migrations
{
    [DbContext(typeof(InfoContext))]
    [Migration("20181126043914_FcmJustDeviceIDAsPK")]
    partial class FcmJustDeviceIDAsPK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MAJServices.Entities.Department", b =>
                {
                    b.Property<string>("DepartmentAcronym")
                        .HasMaxLength(10);

                    b.Property<string>("DepartmentImageUrl");

                    b.Property<string>("HexColor");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("DepartmentAcronym");

                    b.ToTable("Departments");

                    b.HasData(
                        new { DepartmentAcronym = "CELEX", Name = "Centro de Lenguajes Extranjeras" },
                        new { DepartmentAcronym = "CATT", Name = "Comisión Académica de Trabajos Terminales" },
                        new { DepartmentAcronym = "GE", Name = "Gestión Escolar" },
                        new { DepartmentAcronym = "UPIS", Name = "Unidad Politécnica de Integración Social" },
                        new { DepartmentAcronym = "DEAE", Name = "Departamento de Extensión y Apoyos Educativos" },
                        new { DepartmentAcronym = "SUPERADMIN", Name = "SUPERADMIN" }
                    );
                });

            modelBuilder.Entity("MAJServices.Entities.FilePath", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .IsRequired();

                    b.Property<string>("Path")
                        .IsRequired();

                    b.Property<int>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("FilePaths");
                });

            modelBuilder.Entity("MAJServices.Entities.FirebaseCM", b =>
                {
                    b.Property<string>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(250);

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("DeviceId");

                    b.HasIndex("UserId");

                    b.ToTable("FirebaseCMDevices");
                });

            modelBuilder.Entity("MAJServices.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnName("DepartmentId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MAJServices.Entities.RoleIdentity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new { Id = "86f4a4b0-98d3-4467-b0fb-059909930eee", ConcurrencyStamp = "9686ea42-efd3-4274-9903-c5460811fb2d", Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
                        new { Id = "f9119eaa-6cd9-4a91-afd3-464eb96303c3", ConcurrencyStamp = "a6c5cb43-7398-4f68-b285-3a4f785dc3e5", Name = "Admin", NormalizedName = "ADMIN" },
                        new { Id = "e3a0d9b7-2216-4925-9262-82dfe400feef", ConcurrencyStamp = "e23fa376-176e-45ed-8174-e21c6b2e0d07", Name = "Subadmin", NormalizedName = "SUBADMIN" },
                        new { Id = "0e6ee6dc-af85-4e8c-9a40-7090eb80aa70", ConcurrencyStamp = "64e944f4-5d4a-4d9f-9ab7-eaeacdb2f7a2", Name = "General", NormalizedName = "GENERAL" }
                    );
                });

            modelBuilder.Entity("MAJServices.Entities.UserIdentity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("DepartmentAcronym");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserImageUrl");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<bool>("isActive");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentAcronym");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new { Id = "2014630132", AccessFailedCount = 0, ConcurrencyStamp = "db8ce6d4-cdbe-4b80-8936-be6dc1e367f3", DepartmentAcronym = "CATT", EmailConfirmed = false, LastName = "Escutia López", LockoutEnabled = false, Name = "Arturo", NormalizedUserName = "2014630132", PhoneNumberConfirmed = false, SecurityStamp = "4b8376cf-6143-4c69-b4ad-366f5147c750", TwoFactorEnabled = false, UserName = "2014630132", isActive = true },
                        new { Id = "2014378223", AccessFailedCount = 0, ConcurrencyStamp = "2812fbae-e89a-47a5-8156-8994e9d28132", DepartmentAcronym = "CELEX", EmailConfirmed = false, LastName = "Cruz Santiago", LockoutEnabled = false, Name = "Javier", NormalizedUserName = "2014378223", PhoneNumberConfirmed = false, SecurityStamp = "14cf332e-e99d-4781-9242-ad8f6b9ee596", TwoFactorEnabled = false, UserName = "2014378223", isActive = true },
                        new { Id = "2014631903", AccessFailedCount = 0, ConcurrencyStamp = "6b776258-0fc5-4d16-8ff1-8c678abcf862", DepartmentAcronym = "UPIS", EmailConfirmed = false, LastName = "Medina Zarazúa", LockoutEnabled = false, Name = "Miguel", NormalizedUserName = "2014631903", PhoneNumberConfirmed = false, SecurityStamp = "09bd4cd2-5e60-4803-a717-f8d68ecd36d0", TwoFactorEnabled = false, UserName = "2014631903", isActive = true },
                        new { Id = "2014193056", AccessFailedCount = 0, ConcurrencyStamp = "da9e1b74-1823-48d4-b815-f727f54dc735", DepartmentAcronym = "GE", EmailConfirmed = false, LastName = "Servantes Vargas", LockoutEnabled = false, Name = "Axel", NormalizedUserName = "2014193056", PhoneNumberConfirmed = false, SecurityStamp = "16db7e59-273b-4081-ad33-c4ed57922abc", TwoFactorEnabled = false, UserName = "2014193056", isActive = true }
                    );
                });

            modelBuilder.Entity("MAJServices.Entities.UserSubscription", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("DepartmentAcronym")
                        .HasColumnName("DepartmentId");

                    b.HasKey("UserId", "DepartmentAcronym");

                    b.HasIndex("DepartmentAcronym");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MAJServices.Entities.FilePath", b =>
                {
                    b.HasOne("MAJServices.Entities.Post", "Post")
                        .WithMany("FilePaths")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MAJServices.Entities.FirebaseCM", b =>
                {
                    b.HasOne("MAJServices.Entities.UserIdentity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MAJServices.Entities.Post", b =>
                {
                    b.HasOne("MAJServices.Entities.UserIdentity", "Publisher")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MAJServices.Entities.UserIdentity", b =>
                {
                    b.HasOne("MAJServices.Entities.Department", "Department")
                        .WithMany("Members")
                        .HasForeignKey("DepartmentAcronym");
                });

            modelBuilder.Entity("MAJServices.Entities.UserSubscription", b =>
                {
                    b.HasOne("MAJServices.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentAcronym")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MAJServices.Entities.UserIdentity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("MAJServices.Entities.RoleIdentity")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MAJServices.Entities.UserIdentity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MAJServices.Entities.UserIdentity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("MAJServices.Entities.RoleIdentity")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MAJServices.Entities.UserIdentity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MAJServices.Entities.UserIdentity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}