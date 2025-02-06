using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDotnetWebApp.Models;
using System.Threading.Tasks;

namespace MyDotnetWebApp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
      _context = context;
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
      // EF Core will materialize the correct derived type (Teacher or Student)
      var user = await _context.Users.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }
      return Ok(user);
    }

    // POST: api/Users/login
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
      // Placeholder stub logic: you would typically check the credentials,
      // generate a token or set a session, etc.
      // Here, we'll just return a success message.
      return Ok(new { Message = "Login successful (stub)", request.Email });
    }

    // POST: api/Users/logout
    [HttpPost("logout")]
    public IActionResult Logout()
    {
      // Placeholder stub logic: in a real application, you might clear a session or token.
      return Ok(new { Message = "Logout successful (stub)" });
    }
  }

  // A simple DTO for login; 
  public class LoginRequest
  {
    public string Email { get; set; }
    public string Password { get; set; }
  }
}
