using LearningCourseApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCourseApp.Context
{
    public class CourseDbContext : DbContext
    {   
        public CourseDbContext(DbContextOptions<CourseDbContext> context): base(context)
        {

        }
        public DbSet<Course> Courses { get; set; }

    }
}
