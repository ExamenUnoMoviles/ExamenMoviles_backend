using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenMoviles_backend.Data;
using Microsoft.AspNetCore.Mvc;
using ExamenMoviles_backend.Mappers;
using Microsoft.EntityFrameworkCore;
using ExamenMoviles_backend.Dtos.Course;

namespace ExamenMoviles_backend.Controllers
{
  [Route("api/courses")]
  [ApiController]
  public class EventController : ControllerBase
  {
    private readonly ApplicationDBContext _context;
    private readonly string _imagePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages");
    public EventController(ApplicationDBContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var courses = await _context.Courses.ToListAsync();
      Console.WriteLine("JSON enviado al curso: "+courses );
      var coursesDto = courses.Select(c => c.ToDto());
      return Ok(coursesDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromForm] CreateCourseRequestDto courseDto)
    {
      if (courseDto.File == null || courseDto.File.Length == 0)
        return BadRequest("No file uploaded.");

      var courseModel = courseDto.ToCourseFromCreateDto();
      await _context.Courses.AddAsync(courseModel);
      await _context.SaveChangesAsync();

      var fileName = courseModel.Id.ToString() + Path.GetExtension(courseDto.File.FileName);
      var filePath = Path.Combine(_imagePath, fileName);

      using (var stream = new FileStream(filePath, FileMode.Create))
      {
        await courseDto.File.CopyToAsync(stream);
      }

      courseModel.imageUrl = fileName;
      _context.Courses.Update(courseModel);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(getById), new { id = courseModel.Id }, courseModel.ToDto());
    }


[HttpGet("{id}")]
    public async Task<IActionResult> getById([FromRoute] int id)
    {
      var _course = await _context.Courses.FirstOrDefaultAsync(u => u.Id == id);
      if (_course == null)
      {
        return NotFound();
      }
      return Ok(_course.ToDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteCourse([FromRoute] int id)
    {
      var courseModel = await _context.Courses.FirstOrDefaultAsync(_event => _event.Id == id);
      if (courseModel == null)
      {
        return NotFound();
      }
      _context.Courses.Remove(courseModel);

      await _context.SaveChangesAsync();

      return NoContent();
    }


    
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromForm] UpdateCourseRequestDto courseDto)
    {
       Console.WriteLine("Mensaje llegueee");
      var courseModel = await _context.Courses.FirstOrDefaultAsync(_course => _course.Id == id);
      if (courseModel == null)
      {
        return NotFound();
      }
      courseModel.Name = courseDto.name;
      courseModel.Description = courseDto.description;
      courseModel.Schedule = courseDto.schedule;
      courseModel.Professor = courseDto.professor;

       if (courseDto.File != null && courseDto.File.Length > 0){
    
    var fileName = courseModel.Id.ToString() + Path.GetExtension(courseDto.File.FileName);
    var filePath = Path.Combine(_imagePath, fileName);

    if (System.IO.File.Exists(filePath))
    {
        System.IO.File.Delete(filePath);
    }

    // Guardar la nueva imagen
    using (var stream = new FileStream(filePath, FileMode.Create))
    {
        await courseDto.File.CopyToAsync(stream);
    }

    courseModel.imageUrl = fileName;
       }

      await _context.SaveChangesAsync();
       Console.WriteLine("Mensaje llegueee");

       // Send notification to all users subscribed to "event_notifications" topic
      

      return Ok(courseModel.ToDto());
    }

  }
}
