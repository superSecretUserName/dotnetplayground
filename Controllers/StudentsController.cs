using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDotnetWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDotnetWebApp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StudentsController : ControllerBase
  {
    private readonly AppDbContext _context;

    public StudentsController(AppDbContext context)
    {
      _context = context;
    }

    // GET: api/Students
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
    {
      return await _context.Set<Student>().ToListAsync();
    }

    // GET: api/Students/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
      var student = await _context.Set<Student>().FindAsync(id);
      if (student == null)
      {
        return NotFound();
      }
      return student;
    }

    // POST: api/Students
    [HttpPost]
    public async Task<ActionResult<Student>> CreateStudent(Student student)
    {
      _context.Set<Student>().Add(student);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    // PUT: api/Students/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, Student student)
    {
      if (id != student.Id)
      {
        return BadRequest();
      }

      _context.Entry(student).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (await _context.Set<Student>().FindAsync(id) == null)
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

    // DELETE: api/Students/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
      var student = await _context.Set<Student>().FindAsync(id);
      if (student == null)
      {
        return NotFound();
      }

      _context.Set<Student>().Remove(student);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
