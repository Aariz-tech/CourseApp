using LearningCourseApp.Models;
using LearningCourseApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LearningCourseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        readonly ICourseService _courseService;
        
       

        public CourseController(ICourseService courseService  )
        {
            _courseService = courseService;
            
        }
        
        [Route("getAllCourses")]
        [HttpGet]
        public ActionResult GetAllCourses()
        {
            List<Course> courses = _courseService.GetAllCourses();
            return Ok(courses);

        }
        [Route("addCourse")]
        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            bool addCourseStatus = _courseService.AddCourse(course);
            return Ok(addCourseStatus);
        }

        [Route("deleteCourse{id:int}")]
        [HttpDelete]
        public ActionResult DeleteCourse(int id)
        {
            bool courseDeleteStatus = _courseService.DeleteCourse(id);
            return Ok(courseDeleteStatus);
        }

        [Route("updateCourse{id:int}")]
        [HttpPut]
        public ActionResult UpdateCourse(int id, Course course)
        {
            bool courseUpdateStatus = _courseService.UpdateCourse(id, course);
            return Ok(courseUpdateStatus);
        }

        [Route("getCourseById{id:int}")]
        [HttpGet]
        public ActionResult GetCourseById(int id)
        {
            Course course = _courseService.GetCourseById(id);
            return Ok(course);
        }

        [Route("getCourseByName")]
        [HttpGet]
        public ActionResult GetCourseByName(string courseName)
        {
            Course course = _courseService.GetCourseByName(courseName);
            return Ok(course);
        }

        [Route("availableUnavailableCourse{id:int}")]
        [HttpPut]
        public ActionResult AvailableUnAvailableCourse(int id, bool availableUnavailableCourse)
        {
            bool availableUnavailableCourseStatus = _courseService.AvailableUnAvailableCourse(id, availableUnavailableCourse);
            return Ok(availableUnavailableCourseStatus);
        }

        
        









    }
}
