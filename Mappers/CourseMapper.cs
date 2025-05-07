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
        id = courseItem.Id,
        name = courseItem.Name,
        description = courseItem.Description,
        imageUrl = courseItem.imageUrl,
        schedule = courseItem.Schedule,
        professor = courseItem.Professor
      };
    }

     public static Course ToCourseFromCreateDto(this CreateCourseRequestDto createUserRequest)
    {
      return new Course
      {
        Name = createUserRequest.name,
        Description = createUserRequest.description,
        Schedule = createUserRequest.schedule,
        Professor = createUserRequest.professor
      };
    }


  }
}