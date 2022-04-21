using EnrollCourseAPI.Context;
using EnrollCourseAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace EnrollCourseAPI.Repository
{
    public class EnrollCourseRepository : IEnrollCourseRepository
    {
        readonly EnrollCourseDbContext _enrollCourseDbContext;
        public EnrollCourseRepository(EnrollCourseDbContext enrollCourseDbContext)
        {
            _enrollCourseDbContext=enrollCourseDbContext;   
        }

        public int CancelEnrollCourse(EnrollCourse courseEnrollStatus)
        {
            _enrollCourseDbContext.Courses.Remove(courseEnrollStatus);
            return _enrollCourseDbContext.SaveChanges();
        }

        public int EnrollCourse(EnrollCourse course)
        {
            _enrollCourseDbContext.Courses.Add(course);
            return _enrollCourseDbContext.SaveChanges();     
        }

        public List<EnrollCourse> GetAllEnrollCourses()
        {
            return _enrollCourseDbContext.Courses.ToList();
        }

        public List<EnrollCourse> GetAllEnrolledCourseByName(string username)
        {
            return _enrollCourseDbContext.Courses.Where(u=>u.UserName==username).ToList();
        }

        public EnrollCourse GetCourseId(int id)
        {
            return _enrollCourseDbContext.Courses.Where(u => u.Id == id).FirstOrDefault();
        }
    }
}
