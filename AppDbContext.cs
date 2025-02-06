using Microsoft.EntityFrameworkCore;
using MyDotnetWebApp.Models;  // Make sure the namespace matches where your User model is defined

namespace MyDotnetWebApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Add the Users model so EF Core can track it.
        public DbSet<User> Users { get; set; }
        // Add the Teacher and Student models incase we want to retrieve them directly.
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map the base type to a table.
            modelBuilder.Entity<User>().ToTable("Users");

            // Map the derived types to their own tables.
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
        }
    }
}