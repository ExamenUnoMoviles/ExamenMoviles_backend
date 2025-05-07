namespace ExamenMoviles_backend.Dtos.Course
{
  public class CreateCourseRequestDto
  {
    public string name { get; set; }
    public string description { get; set; }
    public IFormFile? File { get; set; }
    public string schedule { get; set; }
    public string professor { get; set; }
  }
}