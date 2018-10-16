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
    [Migration("20181016153826_DepartmentFKandSeeds")]
    partial class DepartmentFKandSeeds
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
                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<string>("Acronym")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("DepartmentImageUrl");

                    b.Property<string>("HexColor");

                    b.HasKey("Name");

                    b.ToTable("Departments");

                    b.HasData(
                        new { Name = "Centro de Lenguajes Extranjeras", Acronym = "CELEX" },
                        new { Name = "Comisión Académica de Trabajos Terminales", Acronym = "CATT" },
                        new { Name = "Gestión Escolar", Acronym = "GE" },
                        new { Name = "Unidad Politécnica de Integración Social", Acronym = "UPIS" },
                        new { Name = "Departamento de Extensión y Apoyos Educativos", Acronym = "DEAE" }
                    );
                });

            modelBuilder.Entity("MAJServices.Entities.FilePath", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .IsRequired();

                    b.Property<int>("IdPost");

                    b.Property<string>("Path")
                        .IsRequired();

                    b.Property<int?>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("FilePaths");
                });

            modelBuilder.Entity("MAJServices.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("Date");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("UserId");

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
                        new { Id = "7df3acd9-73a7-48d2-a8d4-a504ffa89815", ConcurrencyStamp = "503615ff-1f6f-43ea-a395-801f4cb897c2", Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
                        new { Id = "9100af70-37d9-4ea4-bc48-a2ffd0cd1f4b", ConcurrencyStamp = "efaa4104-da9a-4dc0-8152-480f340b9c1a", Name = "Admin", NormalizedName = "ADMIN" },
                        new { Id = "4c57acdd-5d20-45d1-bf0c-f76ab8f18dd5", ConcurrencyStamp = "443f11be-7ff1-48bb-bc31-a304565cca3f", Name = "Subadmin", NormalizedName = "SUBADMIN" },
                        new { Id = "2b310ff8-60f5-4e70-9b2a-e6ee5c73f259", ConcurrencyStamp = "c13ac7d3-3739-428d-b471-15691c5e556a", Name = "General", NormalizedName = "GENERAL" }
                    );
                });

            modelBuilder.Entity("MAJServices.Entities.UserIdentity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Acronym");

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

                    b.HasIndex("Acronym");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new { Id = "2014630132", AccessFailedCount = 0, ConcurrencyStamp = "ed1c34a7-c7ce-48e0-b680-364569d7f4b2", DepartmentAcronym = "CATT", EmailConfirmed = false, LastName = "Escutia López", LockoutEnabled = false, Name = "Arturo", NormalizedUserName = "2014630132", PhoneNumberConfirmed = false, TwoFactorEnabled = false, UserName = "2014630132" },
                        new { Id = "2014378223", AccessFailedCount = 0, ConcurrencyStamp = "4b05f0e2-135e-4683-93d9-73c04420119c", DepartmentAcronym = "CELEX", EmailConfirmed = false, LastName = "Cruz Santiago", LockoutEnabled = false, Name = "Javier", NormalizedUserName = "2014378223", PhoneNumberConfirmed = false, TwoFactorEnabled = false, UserName = "2014378223" },
                        new { Id = "2014631903", AccessFailedCount = 0, ConcurrencyStamp = "5046e0ac-fd1c-4b43-9072-a24f28d916e6", DepartmentAcronym = "UPIS", EmailConfirmed = false, LastName = "Medina Zarazúa", LockoutEnabled = false, Name = "Miguel", NormalizedUserName = "2014631903", PhoneNumberConfirmed = false, TwoFactorEnabled = false, UserName = "2014631903" },
                        new { Id = "2014193056", AccessFailedCount = 0, ConcurrencyStamp = "15fcce1f-4ed3-49ce-bac9-4996bc860a67", DepartmentAcronym = "GE", EmailConfirmed = false, LastName = "Servantes Vargas", LockoutEnabled = false, Name = "Axel", NormalizedUserName = "2014193056", PhoneNumberConfirmed = false, TwoFactorEnabled = false, UserName = "2014193056" }
                    );
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
                    b.HasOne("MAJServices.Entities.Post", "post")
                        .WithMany("FilePaths")
                        .HasForeignKey("PostId");
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
                        .HasForeignKey("Acronym");
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