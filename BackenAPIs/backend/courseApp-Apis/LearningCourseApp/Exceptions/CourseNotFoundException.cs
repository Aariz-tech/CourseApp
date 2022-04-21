using System;

namespace LearningCourseApp.Exceptions
{
    public class CourseNotFoundException:ApplicationException
    {
        public CourseNotFoundException()
        {

        }
        public CourseNotFoundException(string msg):base(msg)
        {

        }
    }
}
