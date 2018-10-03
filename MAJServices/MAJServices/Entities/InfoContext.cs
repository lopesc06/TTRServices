using System;
using MAJServices.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MAJServices.Entities
{
    public class InfoContext : IdentityDbContext<User>
    {
        public InfoContext (DbContextOptions <InfoContext> options) :base (options){
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Posts).WithOne(p => p.User)
                .HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<FilePath> FilePaths { get; set; }
                
    }
}
