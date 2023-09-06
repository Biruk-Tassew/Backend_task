using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
  public class SchoolAppContext : DbContext
  {
    public SchoolAppContext(DbContextOptions<SchoolAppContext> options) : base(options)
    {
    }

    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
  }
}