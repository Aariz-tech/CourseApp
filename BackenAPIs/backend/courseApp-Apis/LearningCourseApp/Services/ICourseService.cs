using LearningCourseApp.Models;
using System.Collections.Generic;

namespace LearningCourseApp.Services
{
    public interface ICourseService
    {
        List<Course> GetAllCourses();
        bool AddCourse(Course course);
        bool DeleteCourse(int id);
        bool UpdateCourse(int id, Course course);
        Course GetCourseById(int id);

        Course GetCourseByName(string courseName);
        bool AvailableUnAvailableCourse(int id, bool availableUnavailableCourse);

        


    }
}
