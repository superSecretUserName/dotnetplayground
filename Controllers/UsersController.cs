using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDotnetWebApp.Models; // Adjust the namespace if your User model is in a different one

namespace MyDotnetWebApp.Controllers
{
  public class UsersController : Controller
  {
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
      _context = context;
    }

    // GET: /Users/Details/5
    // This action retrieves a user by id and passes it to the view.
    public async Task<IActionResult> Details(int id)
    {
      // Try to find the user with the specified id.
      var user = await _context.Users.FindAsync(id);

      if (user == null)
      {
        return NotFound();
      }

      // Return the "Details" view, passing in the user as the model.
      return View(user);
    }
  }
}