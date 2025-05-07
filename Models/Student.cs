namespace ExamenMoviles_backend.Models
{
  public class Student
  {
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
  }
}