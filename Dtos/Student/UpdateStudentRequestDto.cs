namespace ExamenMoviles_backend.Dtos.Student
{
  public class UpdateStudentRequestDto
  {
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int CourseId { get; set; }

  }
}