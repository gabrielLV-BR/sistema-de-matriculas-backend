using Microsoft.EntityFrameworkCore;

public class StudentContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    //
    public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }
}