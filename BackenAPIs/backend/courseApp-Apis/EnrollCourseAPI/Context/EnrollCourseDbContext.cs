using EnrollCourseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EnrollCourseAPI.Context
{
    public class EnrollCourseDbContext:DbContext
    {
        public EnrollCourseDbContext(DbContextOptions<EnrollCourseDbContext> context):base(context)
        {

        }
        public DbSet<EnrollCourse> Courses { get; set; }
    }
}
