using EnrollCourseAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EnrollCourseAPI.Models;
using System.Collections.Generic;

namespace EnrollCourseAPI.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollCourseController : ControllerBase
    {
        readonly IEnrollCourseService _enrollCourseService;
        public EnrollCourseController(IEnrollCourseService enrollCourseService)
        {
            _enrollCourseService=enrollCourseService;
        }
        [Route("enrollCourse")]
        [HttpPost]
        public ActionResult EnrollCourse(EnrollCourse course)
        {
            course.CreatedAt = System.DateTime.Now;
            bool userEnrollCourseStatus = _enrollCourseService.EnrollCourse(course);
            return Ok(userEnrollCourseStatus);

        }
        [Route("cancelEnrollCourse/{id:int}")]
        [HttpDelete]
        public ActionResult CancelEnrollCourse(int id)
        {
            bool cancelEnrollStatus = _enrollCourseService.CancelEnrollCourse(id);
            return Ok(cancelEnrollStatus);
        }
        [Route("getAllEnrollCourse")]
        [HttpGet]

        public ActionResult GetAllEnrollCourses()
        {
            List<EnrollCourse> enrollCourses = _enrollCourseService.GetAllEnrollCourses();
            return Ok(enrollCourses);
        }
        [Route("getAllEnrolledCourseByName")]
        [HttpGet]
        public ActionResult GetAllEnrolledCourseByName(string username)
        {
            List<EnrollCourse> enrolledCourse = _enrollCourseService.GetAllEnrolledCourseByName(username);
            return Ok((enrolledCourse));
        }
    }
}
