using ExamenMoviles_backend.Dtos.Student;
using ExamenMoviles_backend.Models;

namespace ExamenMoviles_backend.Mappers
{
  public static class StudentMapper
  {
    public static StudentDto ToDto(this Student studentItem)
    {
      return new StudentDto
      {
        Id = studentItem.Id,
        Name = studentItem.Name,
        Email = studentItem.Email,
        Phone = studentItem.Phone,
        CourseId = studentItem.CourseId,
        CourseName = studentItem.Course?.Name ?? "Sin curso",
        CourseDescription = studentItem.Course?.Description ?? "Sin descripción de curso.",
        CourseImageUrl = studentItem.Course?.imageUrl ?? "Curso sin imagen.",
        CourseSchedule = studentItem.Course?.Schedule ?? "Curso sin horario.",
        CourseProfessor = studentItem.Course?.Professor ?? "Curso sin profesor."
      };
    }

    public static Student ToStudentFromCreateDto(this CreateStudentRequestDto createStudentRequest){
      return new Student{
        Name = createStudentRequest.Name,
        Email = createStudentRequest.Email,
        Phone = createStudentRequest.Phone,
        CourseId = createStudentRequest.CourseId
      };
    }

  }
}