namespace MyDotnetWebApp.Models
{
  public class Teacher : User
  {
    public string Department { get; set; }
    public string Title { get; set; }

    public double ClassroomHours { get; set; }

    public override string DoWork()
    {
      return "The Teacher is teaching!";
    }
  }
}