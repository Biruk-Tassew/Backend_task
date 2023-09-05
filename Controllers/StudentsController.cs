using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace schoolApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
  private readonly SchoolAppContext _context;

  public StudentsController(SchoolAppContext context)
  {
    _context = context;
  }

  // GET: api/students
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
  {
    return await _context.Students.ToListAsync();
  }

  // GET: api/students/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Student>> GetStudent(int id)
  {
    var Student = await _context.Students.FindAsync(id);

    if (Student == null)
    {
      return NotFound();
    }

    return Student;
  }

  // POST api/students
  [HttpPost]
  public async Task<ActionResult<Student>> PostStudent(Student Student)
  {
    _context.Students.Add(Student);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetStudent), new { id = Student.Id }, Student);
  }

  // PUT api/students/5
  [HttpPut("{id}")]
  public async Task<IActionResult> PutStudent(int id, Student Student)
  {
    if (id != Student.Id)
    {
      return BadRequest();
    }

    _context.Entry(Student).State = EntityState.Modified;
    await _context.SaveChangesAsync();

    return Ok(await _context.Students.FindAsync(id));

  }

  // DELETE api/students/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteStudent(int id)
  {
    var Student = await _context.Students.FindAsync(id);

    if (Student == null)
    {
      return NotFound();
    }

    _context.Students.Remove(Student);
    await _context.SaveChangesAsync();

    return Ok(Student);
  }
}