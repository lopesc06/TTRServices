using System;
using MAJServices.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MAJServices.Entities
{
    public class InfoContext : IdentityDbContext<ApplicationUser>
    {
        public InfoContext (DbContextOptions <InfoContext> options) :base (options){
            Database.Migrate();
        }

        public DbSet<Post> Posts { get; set; }
        public new DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<FilePath> FilePaths { get; set; }
                
    }
}
