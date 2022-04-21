using LearningCourseApp.Context;
using LearningCourseApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace LearningCourseApp.Repository
{
    public class CourseRepository : ICourseRepository
    {
        readonly CourseDbContext _courseDbContext;

        public CourseRepository(CourseDbContext courseDbContext)
        {
            _courseDbContext = courseDbContext;
        }
        public int AddCourse(Course course)
        {
            _courseDbContext.Courses.Add(course);
            return _courseDbContext.SaveChanges();
        }

        

        public int AvailableUnAvailableCourse(bool availableUnavailableCourse, Course course)
        {
            course.IsAvailable = availableUnavailableCourse;
            _courseDbContext.Entry<Course>(course).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _courseDbContext.SaveChanges();
        }

        public int DeleteCourse(Course course)
        {
            _courseDbContext.Courses.Remove(course);
            return _courseDbContext.SaveChanges();
        }

        public List<Course> GetAllCourses()
        {
            return _courseDbContext.Courses.Where(u => u.IsAvailable == true).ToList();
        }

        public Course GetCourseById(int id)
        {
            return _courseDbContext.Courses.Where(u => u.Id == id).FirstOrDefault();
        }

        public Course GetCourseByName(string courseName)
        {
            return _courseDbContext.Courses.Where(u => u.CourseName == courseName).FirstOrDefault();
        }

       

        public int UpdateCourse(Course course)
        {
            _courseDbContext.Entry<Course>(course).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _courseDbContext.SaveChanges();
        }
    }
}
