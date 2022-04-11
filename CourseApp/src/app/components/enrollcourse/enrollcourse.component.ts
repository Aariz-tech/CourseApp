import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { EnrollCourse } from 'src/app/models/enroll-course';
import { Logincourse } from 'src/app/models/logincourse';
import { CourseService } from 'src/app/services/course.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-enrollcourse',
  templateUrl: './enrollcourse.component.html',
  styleUrls: ['./enrollcourse.component.css']
})
export class EnrollcourseComponent implements OnInit {

  loginCourse:Logincourse;
  
  constructor(private courseService:CourseService, private router:Router) {
    this.loginCourse = new Logincourse();
   }

  ngOnInit(): void {
  }

  loginCourseData(courseFormRef:NgForm)
  {
    this.loginCourse = courseFormRef.value;
   
    this.courseService.loginCourse(this.loginCourse).subscribe(res=>{
      
      let jsonObject = JSON.stringify(res);
      let jsonToken=JSON.parse(jsonObject);
      
      localStorage.setItem('CourseTOKEN',jsonToken["Token"]);
      localStorage.setItem('CourseName',jsonToken["CourseName"]);
      localStorage.setItem('CourseDescription',jsonToken["CourseDescription"]);
      localStorage.setItem('CoursePrice',jsonToken["CoursePrice"]);
      
      Swal.fire(
        'Enrolled Course',
        'Enrolled Course Success',
        'success'
      )
      this.enrolledCourseSuccess();
      this.router.navigate(['getallcourses']);
      
    });

  }
  enrolledCourseSuccess()
    {
      
      var userName = localStorage.getItem("UserName");
      var userEmail = localStorage.getItem("UserEmail");
      var courseName = localStorage.getItem("CourseName");
      var courseDescription = localStorage.getItem("CourseDescription");
      var coursePrice = localStorage.getItem("CoursePrice");
      console.log(userName);
      console.log(userEmail);
      console.log(courseName);
      console.log(courseDescription);
      console.log(coursePrice);
      var enrolledCourse: EnrollCourse = {
      };
      enrolledCourse.userName=JSON.parse(localStorage.getItem('UserName') || '{}')
      enrolledCourse.userEmail = JSON.parse(localStorage.getItem('UserEmail') || '{}')
      enrolledCourse.courseName = JSON.parse(localStorage.getItem('CourseName') || '{}')
      enrolledCourse.courseDescription = JSON.parse(localStorage.getItem('CourseDescription') || '{}')
      enrolledCourse.coursePrice = JSON.parse(localStorage.getItem('CoursePrice') || '')
      
      console.log(enrolledCourse.userEmail)
      //enrolledCourse:EnrollCourse;
      //enrolledCourse.userName = userName;

      this.courseService.enrolledMyCourse(enrolledCourse).subscribe(res=>{
        if(res)
      {
        console.log("Course Enrolled Success");
        
        this.router.navigate(['getallcourses']);
      }
      else 
      {
        console.log("Course Enrolled Failed");
      }
      })
      
    }

}

