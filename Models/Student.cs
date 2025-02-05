namespace MyDotnetWebApp.Models
{
  public class Student : User
  {
    public required string Major { get; set; }
    public required string Year { get; set; }

    public required double CreditHours { get; set; }

    public override string DoWork()
    {
      return "The Student is studying!";
    }
  }
}