using LearningCourseApp.Models;
using System.Collections.Generic;

namespace LearningCourseApp.Repository
{
    public interface ICourseRepository
    {
        int AvailableUnAvailableCourse(bool availableUnavailableCourse, Course course);
        Course GetCourseById(int id);

        
        int DeleteCourse(Course course);
        int UpdateCourse(Course course);
        List<Course> GetAllCourses();
        int AddCourse(Course course);
       
        Course GetCourseByName(string courseName);
        
    }
}
