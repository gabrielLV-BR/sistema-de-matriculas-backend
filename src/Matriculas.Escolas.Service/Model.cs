using Microsoft.EntityFrameworkCore;

class SchoolContext : DbContext
{
    public DbSet<School> Schools;

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options) { }
}