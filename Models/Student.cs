using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
  public class Student
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Age { get; set; }
    public int Class { get; set; }
  }
}