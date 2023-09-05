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
        public DbSet<Student> Students { get; set; } // Add DbSet for Student model

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional: Configure any additional relationships or constraints
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Teacher)
                .WithMany()
                .HasForeignKey(s => s.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}