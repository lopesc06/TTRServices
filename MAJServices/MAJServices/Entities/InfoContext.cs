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
            modelBuilder.Entity<UserIdentity>().HasMany(u => u.Posts).WithOne(p => p.User)
                .HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<FilePath> FilePaths { get; set; }
                
    }
}
