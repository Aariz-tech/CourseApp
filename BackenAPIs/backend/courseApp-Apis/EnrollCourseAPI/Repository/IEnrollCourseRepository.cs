using EnrollCourseAPI.Models;
using System.Collections.Generic;

namespace EnrollCourseAPI.Repository
{
    public interface IEnrollCourseRepository
    {
        int EnrollCourse(EnrollCourse course);
        EnrollCourse GetCourseId(int id);
        int CancelEnrollCourse(EnrollCourse courseEnrollStatus);
        List<EnrollCourse> GetAllEnrollCourses();
        List<EnrollCourse> GetAllEnrolledCourseByName(string username);
    }
}
