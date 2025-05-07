namespace ExamenMoviles_backend.Dtos.Student

{
  public class StudentDto
  {
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int CourseId { get; set; }
    public string CourseName { get; set; } = null!;
    public string CourseDescription { get; set; } = null!;
    public string CourseImageUrl { get; set; } = null!;
    public string CourseSchedule { get; set; } = null!;
    public string CourseProfessor { get; set; } = null!;
  }
}