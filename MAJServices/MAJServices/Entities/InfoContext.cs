using System;
using Microsoft.EntityFrameworkCore;

namespace MAJServices.Entities
{
    public class InfoContext : DbContext
    {
        public InfoContext (DbContextOptions <InfoContext> options) :base (options){
            Database.Migrate();
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
                
    }
}
