using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyDotnetWebApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyDotnetWebApp
{
  public static class SeedData
  {
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
      using var context = new AppDbContext(
          serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

      // Check if any users already exist.
      if (context.Users.Any())
      {
        return;   // Database has been seeded
      }

      // Create a few Teacher objects
      var teachers = new Teacher[]
      {
                new Teacher
                {
                    FirstName = "Alice",
                    LastName = "Smith",
                    Email = "alice.smith@example.com",
                    Password = "password1",
                    Department = "Mathematics",
                    Title = "Professor",
                    ClassroomHours = 12.0
                },
                new Teacher
                {
                    FirstName = "Bob",
                    LastName = "Jones",
                    Email = "bob.jones@example.com",
                    Password = "password2",
                    Department = "History",
                    Title = "Lecturer",
                    ClassroomHours = 10.0
                }
      };

      // Create a few Student objects
      var students = new Student[]
      {
                new Student
                {
                    FirstName = "Charlie",
                    LastName = "Brown",
                    Email = "charlie.brown@example.com",
                    Password = "password3",
                    Major = "Physics",
                    Year = "Sophomore",
                    CreditHours = 15.0
                },
                new Student
                {
                    FirstName = "Dana",
                    LastName = "White",
                    Email = "dana.white@example.com",
                    Password = "password4",
                    Major = "Biology",
                    Year = "Freshman",
                    CreditHours = 12.0
                }
      };

      // Add both teachers and students to the Users DbSet.
      context.Users.AddRange(teachers);
      context.Users.AddRange(students);

      // Save changes to the database.
      await context.SaveChangesAsync();
    }
  }
}
