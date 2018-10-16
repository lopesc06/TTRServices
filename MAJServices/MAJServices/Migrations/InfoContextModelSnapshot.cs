﻿// <auto-generated />
using System;
using MAJServices.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MAJServices.Migrations
{
    [DbContext(typeof(InfoContext))]
    partial class InfoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        new { Id = "13414737-621a-49c7-ae8f-53ef3d65669e", ConcurrencyStamp = "4742a372-1d14-4ac9-9773-aa8557e39914", Name = "SuperAdmin" },
                        new { Id = "8eda1e6e-6e50-410e-a782-dab773a2fd32", ConcurrencyStamp = "bcb5c558-3c6b-4cda-a76c-cff41d980505", Name = "Admin" },
                        new { Id = "4def01bf-dbf1-4374-86bb-089f9c62a9d7", ConcurrencyStamp = "e6095ff2-73fe-443d-adfb-ae94ffb26efb", Name = "Subadmin" },
                        new { Id = "9f79b910-7336-499a-8bfc-bf08c799b7e2", ConcurrencyStamp = "b799ba75-8507-4a63-bdd5-fa5434fc0127", Name = "General" }
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
                        new { Id = "2014630132", AccessFailedCount = 0, ConcurrencyStamp = "c13dfeec-d988-4c0f-b60d-f5cb824a8541", DepartmentAcronym = "CATT", EmailConfirmed = false, LastName = "Escutia López", LockoutEnabled = false, Name = "Arturo", PhoneNumberConfirmed = false, TwoFactorEnabled = false, UserName = "2014630132" },
                        new { Id = "2014378223", AccessFailedCount = 0, ConcurrencyStamp = "84f63bb8-eeb7-4797-bbaf-bf4ce43d3ab0", DepartmentAcronym = "CELEX", EmailConfirmed = false, LastName = "Cruz Santiago", LockoutEnabled = false, Name = "Javier", PhoneNumberConfirmed = false, TwoFactorEnabled = false, UserName = "2014378223" },
                        new { Id = "2014631903", AccessFailedCount = 0, ConcurrencyStamp = "186c7ab5-8f53-47db-9b8a-b4d633e16772", DepartmentAcronym = "UPIS", EmailConfirmed = false, LastName = "Medina Zarazúa", LockoutEnabled = false, Name = "Miguel", PhoneNumberConfirmed = false, TwoFactorEnabled = false, UserName = "2014631903" },
                        new { Id = "2014193056", AccessFailedCount = 0, ConcurrencyStamp = "19e04da0-adff-4617-8775-c3f0523a6e56", DepartmentAcronym = "GE", EmailConfirmed = false, LastName = "Servantes Vargas", LockoutEnabled = false, Name = "Axel", PhoneNumberConfirmed = false, TwoFactorEnabled = false, UserName = "2014193056" }
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
