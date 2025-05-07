using ExamenMoviles_backend.Data;
using ExamenMoviles_backend.Dtos.Student;
using Microsoft.AspNetCore.Mvc;
using ExamenMoviles_backend.Mappers;
using Microsoft.EntityFrameworkCore;

namespace ExamenMoviles_backend.Controllers
{
  [Route("api/student")]
  [ApiController]
  public class StudentController : ControllerBase
  {
    private readonly ApplicationDBContext _context;
    public StudentController(ApplicationDBContext context)
    {
      _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateStudentRequestDto studentDto)
    {
      var studenModel = studentDto.ToStudentFromCreateDto();

      // Check if the course exists
      var courseModel = await _context.Courses.FirstOrDefaultAsync(_course => _course.Id == studenModel.CourseId);
      if (courseModel == null) return NotFound("Curso no encontrado.");

      await _context.Student.AddAsync(studenModel);
      await _context.SaveChangesAsync();

      return Ok(studenModel.ToDto());
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var students = await _context.Student.ToListAsync();
      var studentDto = students.Select(s => s.ToDto());
      return Ok(studentDto);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      var studentModel = await _context.Student.FirstOrDefaultAsync(_student => _student.Id == id);
      if (studentModel == null) return NotFound("Estudiante no encontrado.");

      _context.Student.Remove(studentModel);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStudentRequestDto studentDto)
    {
      var studenModel = await _context.Student.FirstOrDefaultAsync(_student => _student.Id == id);
      if (studenModel == null) return NotFound();

      studenModel.Name = studentDto.Name;
      studenModel.Email = studentDto.Email;
      studenModel.Phone = studentDto.Phone;
      studenModel.CourseId = studentDto.CourseId;

      await _context.SaveChangesAsync();

      
      return Ok(studenModel.ToDto());
    }
  }
}
