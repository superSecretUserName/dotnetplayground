using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDotnetWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDotnetWebApp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TeachersController : ControllerBase
  {
    private readonly AppDbContext _context;

    public TeachersController(AppDbContext context)
    {
      _context = context;
    }

    // GET: api/Teachers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
    {
      return await _context.Set<Teacher>().ToListAsync();
    }

    // GET: api/Teachers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Teacher>> GetTeacher(int id)
    {
      var teacher = await _context.Set<Teacher>().FindAsync(id);
      if (teacher == null)
      {
        return NotFound();
      }
      return teacher;
    }

    // POST: api/Teachers
    [HttpPost]
    public async Task<ActionResult<Teacher>> CreateTeacher(Teacher teacher)
    {
      _context.Set<Teacher>().Add(teacher);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetTeacher), new { id = teacher.Id }, teacher);
    }

    // PUT: api/Teachers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeacher(int id, Teacher teacher)
    {
      if (id != teacher.Id)
      {
        return BadRequest();
      }

      _context.Entry(teacher).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (await _context.Set<Teacher>().FindAsync(id) == null)
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    // DELETE: api/Teachers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeacher(int id)
    {
      var teacher = await _context.Set<Teacher>().FindAsync(id);
      if (teacher == null)
      {
        return NotFound();
      }

      _context.Set<Teacher>().Remove(teacher);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
