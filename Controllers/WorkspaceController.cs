using Microsoft.AspNetCore.Mvc;
using MyDotnetWebApp.Models;

namespace MyDotnetWebApp.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WorkspaceController : ControllerBase
  {
    private readonly AppDbContext _context;

    public WorkspaceController(AppDbContext context)
    {
      _context = context;
    }
    // GET: /workspace
    [HttpGet]
    public async Task<IActionResult> GetWorkspaceDataAsync()
    {
      var teacher = new Teacher();
      teacher.Department = "Art History";
      teacher.Title = "Lecturer";
      teacher.ClassroomHours = 3.4;
      teacher.FirstName = "billy";
      teacher.LastName = "bob";
      teacher.Email = "bob@asdf.com";
      teacher.Password = "elephant";

      _context.Add(teacher); // Alternatively: _context.Teachers.Add(teacher);
                             // Save the changes to the database

      await _context.SaveChangesAsync();
      return Ok(teacher); // Returns a 200 OK response with JSON

    }
  }
}
