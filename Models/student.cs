using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Department{ get; set; }
        public int TeacherId { get; set; }  // Foreign key for the Teacher relationship

        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }  // Navigation property for the Teacher relationship
    }
}