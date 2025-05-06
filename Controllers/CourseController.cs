using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenMoviles_backend.Data;
using Microsoft.AspNetCore.Mvc;
using ExamenMoviles_backend.Mappers;
using Microsoft.EntityFrameworkCore;

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
      var coursesDto = courses.Select(c => c.ToDto());
      return Ok(coursesDto);
    }

  }
}
