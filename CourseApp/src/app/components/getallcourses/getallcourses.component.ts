import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Course } from 'src/app/models/course';
import { EnrollCourse } from 'src/app/models/enroll-course';

import { CourseService } from 'src/app/services/course.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-getallcourses',
  templateUrl: './getallcourses.component.html',
  styleUrls: ['./getallcourses.component.css']
})
export class GetallcoursesComponent implements OnInit {

  
  
  courses?:Array<Course>;
  constructor(private courseService:CourseService, private router:Router) {
    
   }


   

  ngOnInit(): void {
    this.courseService.getAllCourses().subscribe(res=>{
      console.log(res);
      this.courses = res;
    });
  }
  enrollMyCourse(value1,value2,value3,value4)
  {
    var userName = localStorage.getItem("UserName");
    var userEmail = localStorage.getItem("UserEmail");
    var userId = localStorage.getItem('')
    
    console.log(value4.innerText);
    
    var courseName = value1.innerText;
    var courseDescription = value2.innerText;
    var coursePrice = value3.innerText;
    var splitsCoursePrice = coursePrice.split(".");
    console.log(splitsCoursePrice[1]);
    
    var enrolledCourse: EnrollCourse = {
      name:String(courseName),
      price:Number(splitsCoursePrice[1]),
      description:String(courseDescription),
      userName:userName!,
      email:userEmail!,


    };
    console.log(enrolledCourse);
    if(userName != null)
    {
      this.courseService.enrolledMyCourse(enrolledCourse).subscribe(res=>{
        if(res)
      {
        Swal.fire(
          'Enrolled Course',
          'Enrolled Course Success',
          'success'
        )
        console.log("Course Enrolled Success");
        
        this.router.navigate(['enrollcourses']);
      }
      else 
      {
        console.log("Course Enrolled Failed");
      }
      })
    }
    else 
    {
      this.router.navigate(["login"]);
    }
    
  }
  
  }
    


  
