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
    var student = await _context.Students.FindAsync(id);

    if (student is null)
    {
      return NotFound();
    }

    return student;
  }

    // GET: api/students/ filterByStudentNumber/123456
  [HttpGet("filterByStudentNumber/{studentNumber}")]
    public async Task<ActionResult<Student>> GetStudent(string studentNumber)
    {
        var student = await _context.Students.FirstOrDefaultAsync(student => student.StudentNumber == studentNumber);
    
        if (student is null)
        {
            return NotFound();
        }
    
        return Ok(student);
    }

  // POST api/students/ filterByCGPA/3.5
  [HttpGet("filterByCGPA/{cgpa}")]
  public async Task<ActionResult<Student>> PostStudent(int cgpa)
  {
    var students = await _context.Students.Where(student => student.CGPA >= cgpa).ToListAsync();

    if (students.Count == 0)
    {
      return NotFound();
    }

    return Ok(students);
  }

  // POST api/students
  [HttpPost]
  public async Task<ActionResult<Student>> PostStudent(Student student)
  {
    _context.Students.Add(student);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
  }

  // PUT api/students/5
  [HttpPut("{id}")]
  public async Task<IActionResult> PutStudent(int id, Student student)
  {
    if (id != student.Id)
    {
      return BadRequest();
    }

    _context.Entry(student).State = EntityState.Modified;
    await _context.SaveChangesAsync();

    return Ok(await _context.Students.FindAsync(id));

  }

  // DELETE api/students/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteStudent(int id)
  {
    var student = await _context.Students.FindAsync(id);

    if (student is null)
    {
      return NotFound();
    }

    _context.Students.Remove(student);
    await _context.SaveChangesAsync();

    return Ok(student);
  }
}