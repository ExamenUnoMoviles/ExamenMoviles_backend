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
    public async Task<IActionResult> Create([FromBody] CreateStudentRequestDto studentDto)
    {
      var studenModel = studentDto.ToStudentFromCreateDto();

      // Check if the course exists
      var courseModel = await _context.Courses.FirstOrDefaultAsync(_course => _course.Id == studenModel.CourseId);
      if (courseModel == null) return NotFound("Curso no encontrado.");

      await _context.Student.AddAsync(studenModel);
      await _context.SaveChangesAsync();
     await FirebaseHelper.SendPushNotificationToTopicAsync(
          topic: "Examen_Moviles",
          title: "Estudiante Creado!",
          body: $"El estudiante \"{studenModel.Name}\" se ha creado correctamente!"
      );
      return Ok(studenModel.ToDto());
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetAll([FromRoute] int id)
    {
      var students = await _context.Student
        .Where(s => s.CourseId == id)
        .ToListAsync();

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

    [HttpGet("unique/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var student = await _context.Student
    .FirstOrDefaultAsync(s => s.Id == id);

      if (student == null) return NotFound();

      var studentDto = student.ToDto();
      return Ok(studentDto);
    }
  }
}
