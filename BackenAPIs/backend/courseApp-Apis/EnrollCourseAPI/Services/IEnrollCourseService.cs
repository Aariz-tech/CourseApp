using EnrollCourseAPI.Models;
using System.Collections.Generic;

namespace EnrollCourseAPI.Services
{
    public interface IEnrollCourseService
    {
        bool EnrollCourse(EnrollCourse course);
        bool CancelEnrollCourse(int id);
        List<EnrollCourse> GetAllEnrollCourses();
        List<EnrollCourse> GetAllEnrolledCourseByName(string username);
    }
}
