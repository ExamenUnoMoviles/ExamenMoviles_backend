using ExamenMoviles_backend.Dtos.Course;
using ExamenMoviles_backend.Models;

namespace ExamenMoviles_backend.Mappers
{
  public static class CourseMapper
  {
    public static CoursetDto ToDto(this Course courseItem)
    {
      return new CoursetDto
      {
        Id = courseItem.Id,
        Name = courseItem.Name,
        Description = courseItem.Description,
        imageUrl = courseItem.imageUrl,
        Schedule = courseItem.Schedule,
        Professor = courseItem.Professor
      };
    }


  }
}