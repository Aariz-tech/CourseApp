using LearningCourseApp.Exceptions;
using LearningCourseApp.Models;
using LearningCourseApp.Repository;
using System;
using System.Collections.Generic;

namespace LearningCourseApp.Services
{
    public class CourseService : ICourseService
    {   
        readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public bool AddCourse(Course course)
        {
            Course courseAddDetailsExist =_courseRepository.GetCourseByName(course.CourseName);
            if (courseAddDetailsExist == null)
            {
                int courseAddResult = _courseRepository.AddCourse(course);
                if (courseAddResult == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        
        public bool AvailableUnAvailableCourse(int id, bool availableUnavailableCourse)
        {
            Course courseExistToUpdateStatus = _courseRepository.GetCourseById(id);
            if (courseExistToUpdateStatus == null)
            {
                return false;
            }
            else
            {
                int availableUnavailableStatus = _courseRepository.AvailableUnAvailableCourse(availableUnavailableCourse, courseExistToUpdateStatus);
                if (availableUnavailableStatus == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteCourse(int id)
        {
            Course courseExistToDelete = _courseRepository.GetCourseById(id);
            if(courseExistToDelete == null)
            {
                return false;
            }
            else
            {
                int courseExistStatus = _courseRepository.DeleteCourse(courseExistToDelete);
                if(courseExistStatus == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<Course> GetAllCourses()
        {
            return _courseRepository.GetAllCourses();
        }

        public Course GetCourseById(int id)
        {
            return _courseRepository.GetCourseById(id);
        }

        public Course GetCourseByName(string courseName)
        {
            return _courseRepository.GetCourseByName(courseName);
        }

        

        public bool UpdateCourse(int id, Course course)
        {   
            course.Id = id;
            int updateCourseStatus = _courseRepository.UpdateCourse(course);
            if (updateCourseStatus == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
