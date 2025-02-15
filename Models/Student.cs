namespace MyDotnetWebApp.Models
{
  public class Student : User
  {
    public string Major { get; set; }
    public string Year { get; set; }

    public double CreditHours { get; set; }

    public override string DoWork()
    {
      return "The Student is studying!";
    }
  }
}