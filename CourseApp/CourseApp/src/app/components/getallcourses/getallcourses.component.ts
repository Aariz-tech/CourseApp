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
  userName?:String;
  

  urls?: string;
  constructor(private courseService:CourseService, private router:Router) {
    
   }


   

  ngOnInit(): void {
    this.userName = localStorage.getItem("UserName")!;
    this.courseService.getAllCourses().subscribe(res=>{
      console.log(res);
      this.courses = res;
    });
    
    
    
    
    
  }
  enrollMyCourse(course)
  {
    var userName = localStorage.getItem("UserName");
    
    var userEmail = localStorage.getItem("UserEmail");
    var userId = localStorage.getItem('')
    
    
    
    var courseName = course.courseName;
    var courseDescription = course.courseDescription;
    var coursePrice = course.coursePrice;
    // var splitsCoursePrice = coursePrice.split(".");
    var imageUrl = course.imageUrl;
    var documentUrl = course.documentUrl;
    var videoUrl = course.videoUrl;
    // console.log(splitsCoursePrice[1]);
    
    var enrolledCourse: EnrollCourse = {
      name:String(courseName),
      price:Number(coursePrice),
      description:String(courseDescription),
      userName:userName!,
      email:userEmail!,
      imageUrl:String(imageUrl),
      documentUrl:String(documentUrl),
      videoUrl:String(videoUrl)


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
  deleteCourse(id)
  {
    console.log(id);
    this.courseService.deleteCourse(id).subscribe(res=>{
      if(res)
      {
        Swal.fire(
          'Course deleted',
          'Course deleted Successfully',
          'success'
        )
        window.location.reload();
        console.log("Deleted Course");
        
      }
      else
      {
        console.log("Getting Some Error");
        
      }
    })
    
  }

  updateCourse(id)
  {
    console.log(id);
    this.router.navigate(['/update-course'], { queryParams: { id: id } }); 
    
  }
  
  
  }
    


  
