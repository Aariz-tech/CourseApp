using EnrollCourseAPI.Models;
using EnrollCourseAPI.Repository;
using System;
using System.Collections.Generic;

namespace EnrollCourseAPI.Services
{
    public class EnrollCourseService : IEnrollCourseService
    {
        readonly IEnrollCourseRepository _enrollCourseRepository;
        public EnrollCourseService(IEnrollCourseRepository enrollCourseRepository)
        {
            _enrollCourseRepository=enrollCourseRepository;
        }

        public bool CancelEnrollCourse(int id)
        {
            EnrollCourse courseEnrollStatus = _enrollCourseRepository.GetCourseId(id);
            if (courseEnrollStatus != null)
            {
                int cancelEnroll = _enrollCourseRepository.CancelEnrollCourse(courseEnrollStatus);
                if (cancelEnroll == 1)
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

        
        public bool EnrollCourse(EnrollCourse course)
        {
            int enrollCourseStatus=_enrollCourseRepository.EnrollCourse(course);
            if (enrollCourseStatus==1)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

        public List<EnrollCourse> GetAllEnrollCourses()
        {
            return _enrollCourseRepository.GetAllEnrollCourses();
        }

        public List<EnrollCourse> GetAllEnrolledCourseByName(string username)
        {
            return _enrollCourseRepository.GetAllEnrolledCourseByName(username);
        }
    }
}
