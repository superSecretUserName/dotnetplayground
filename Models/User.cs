using System.Text.Json.Serialization;

namespace MyDotnetWebApp.Models
{
  [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
  [JsonDerivedType(typeof(Teacher), "teacher")]
  [JsonDerivedType(typeof(Student), "student")]
  public abstract class User
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }


    [JsonIgnore]
    public string Password { get; set; }

    public virtual string DoWork()
    {
      return "The User doing user things!";
    }
  }
}