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
    }
}