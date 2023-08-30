using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
  public class Student
  {
    [Key]
    [Column("student_id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("student_number")]
    public string StudentNumber { get; set; }
    [Column("cgpa")]
    public double CGPA { get; set; }
  }
}