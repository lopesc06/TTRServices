using System;
using MAJServices.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MAJServices.Entities
{
    //The third parameter is the data type of the primary key for the UserIdentity and RoleIdentity classes.
    public class InfoContext : IdentityDbContext<UserIdentity,RoleIdentity,string>
    {
        public InfoContext (DbContextOptions <InfoContext> options) :base (options){
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserIdentity>().HasMany(u => u.Posts).WithOne(p => p.Publisher)
                .HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserSubscription>().HasKey(k => new { k.UserId, k.DepartmentAcronym });
            //modelBuilder.Entity<Department>().HasMany(d => d.Members).WithOne(u => u.Department)
            //    .HasForeignKey(u => u.DepartmentAcronym);
            InfoContextSeeds.SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserSubscription> Subscriptions { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<FilePath> FilePaths { get; set; }
                
    }
}
