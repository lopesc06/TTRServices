using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MAJServices.Entities
{
    public static class InfoContextSeeds
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedDepartments(modelBuilder);
            SeedRoles(modelBuilder);
            SeedUsers(modelBuilder);
        }

        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleIdentity>().HasData(
                new RoleIdentity
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin".ToUpper()
                },
                new RoleIdentity
                {
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new RoleIdentity
                {
                    Name = "Subadmin",
                    NormalizedName = "Subadmin".ToUpper()
                },
                new RoleIdentity
                {
                    Name = "General",
                    NormalizedName = "General".ToUpper()
                });
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserIdentity>().HasData(
                new UserIdentity
                {
                    Id = "2014630132",
                    UserName = "2014630132",
                    NormalizedUserName = "2014630132".ToUpper(),
                    Name = "Arturo",
                    LastName = "Escutia López",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    DepartmentAcronym = "CATT",
                },
                 new UserIdentity
                 {
                     Id = "2014378223",
                     UserName = "2014378223",
                     NormalizedUserName = "2014378223".ToUpper(),
                     Name = "Javier",
                     LastName = "Cruz Santiago",
                     SecurityStamp = Guid.NewGuid().ToString(),
                     DepartmentAcronym = "CELEX"
                 },
                 new UserIdentity
                 {
                     Id = "2014631903",
                     UserName = "2014631903",
                     NormalizedUserName = "2014631903".ToUpper(),
                     Name = "Miguel",
                     LastName = "Medina Zarazúa",
                     SecurityStamp = Guid.NewGuid().ToString(),
                     DepartmentAcronym = "UPIS"
                 },
                 new UserIdentity
                 {
                     Id = "2014193056",
                     UserName = "2014193056",
                     NormalizedUserName = "2014193056".ToUpper(),
                     Name = "Axel",
                     LastName = "Servantes Vargas",
                     SecurityStamp = Guid.NewGuid().ToString(),
                     DepartmentAcronym = "GE"
                 });
        }

        private static void SeedDepartments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Name = "Centro de Lenguajes Extranjeras",
                    DepartmentAcronym = "CELEX"
                },
                 new Department
                 {
                     Name = "Comisión Académica de Trabajos Terminales",
                     DepartmentAcronym = "CATT"
                 },
                 new Department
                 {
                     Name = "Gestión Escolar",
                     DepartmentAcronym = "GE"
                 },
                 new Department
                 {
                     Name = "Unidad Politécnica de Integración Social",
                     DepartmentAcronym = "UPIS"
                 },
                 new Department
                 {
                     Name = "Departamento de Extensión y Apoyos Educativos",
                     DepartmentAcronym = "DEAE"
                 });
        }

    }
}
