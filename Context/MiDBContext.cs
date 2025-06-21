using LAB12_ALDANA_API.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB12_ALDANA_API.Context
{
    public class MiDBContext : DbContext
    {
        public MiDBContext(DbContextOptions<MiDBContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
