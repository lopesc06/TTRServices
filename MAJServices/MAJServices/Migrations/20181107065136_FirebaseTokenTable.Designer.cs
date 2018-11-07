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
    [Migration("20181107065136_FirebaseTokenTable")]
    partial class FirebaseTokenTable
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
                        new { DepartmentAcronym = "DEAE", Name = "Departamento de Extensión y Apoyos Educativos" }
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
                    b.Property<string>("UserId");

                    b.Property<string>("DeviceId")
                        .HasMaxLength(250);

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("UserId", "DeviceId");

                    b.ToTable("FirebaseCMDevices");
                });

            modelBuilder.Entity("MAJServices.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("Date");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

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
                        new { Id = "adc65061-5002-4975-a3ac-403ccc1e240b", ConcurrencyStamp = "40c19764-6820-4baa-ba10-7aa908ca8c03", Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
                        new { Id = "ead63431-fafd-4a1b-a0a8-fb0d95282c51", ConcurrencyStamp = "fffd99cb-6b96-4b97-857b-e258559a7726", Name = "Admin", NormalizedName = "ADMIN" },
                        new { Id = "cbd420f5-f4b7-4ded-b02b-0be3f0e7cae8", ConcurrencyStamp = "1ee83260-19ac-47d3-9e7f-962fdcf8e36c", Name = "Subadmin", NormalizedName = "SUBADMIN" },
                        new { Id = "754ff240-a94d-42a2-8f1e-bcf8b4395de5", ConcurrencyStamp = "2b4ec8ae-09de-4605-a1ef-5377ca7c2c2e", Name = "General", NormalizedName = "GENERAL" }
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
                        new { Id = "2014630132", AccessFailedCount = 0, ConcurrencyStamp = "5de87f13-b52f-4e76-b863-7ea45d1204c0", DepartmentAcronym = "CATT", EmailConfirmed = false, LastName = "Escutia López", LockoutEnabled = false, Name = "Arturo", NormalizedUserName = "2014630132", PhoneNumberConfirmed = false, SecurityStamp = "f4bdee45-44e8-4dbd-bbab-45dc0221c6d2", TwoFactorEnabled = false, UserName = "2014630132" },
                        new { Id = "2014378223", AccessFailedCount = 0, ConcurrencyStamp = "f0c52c28-b268-474f-a6f2-11a980a6e57e", DepartmentAcronym = "CELEX", EmailConfirmed = false, LastName = "Cruz Santiago", LockoutEnabled = false, Name = "Javier", NormalizedUserName = "2014378223", PhoneNumberConfirmed = false, SecurityStamp = "388dc68f-2fbd-4812-9c0c-e13d8d10c7b5", TwoFactorEnabled = false, UserName = "2014378223" },
                        new { Id = "2014631903", AccessFailedCount = 0, ConcurrencyStamp = "7afc9e7c-d58c-48c6-8081-36572250802c", DepartmentAcronym = "UPIS", EmailConfirmed = false, LastName = "Medina Zarazúa", LockoutEnabled = false, Name = "Miguel", NormalizedUserName = "2014631903", PhoneNumberConfirmed = false, SecurityStamp = "df7a570a-7285-40ec-9a74-080f410c8dfa", TwoFactorEnabled = false, UserName = "2014631903" },
                        new { Id = "2014193056", AccessFailedCount = 0, ConcurrencyStamp = "78ce0c37-6b5c-4336-8e99-a1a743eca47f", DepartmentAcronym = "GE", EmailConfirmed = false, LastName = "Servantes Vargas", LockoutEnabled = false, Name = "Axel", NormalizedUserName = "2014193056", PhoneNumberConfirmed = false, SecurityStamp = "a2b05cce-a925-43d5-994e-67ee02c6824b", TwoFactorEnabled = false, UserName = "2014193056" }
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