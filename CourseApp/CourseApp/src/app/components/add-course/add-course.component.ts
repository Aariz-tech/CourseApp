import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Course } from 'src/app/models/course';
import { CourseService } from 'src/app/services/course.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-course',
  templateUrl: './add-course.component.html',
  styleUrls: ['./add-course.component.css']
})
export class AddCourseComponent implements OnInit {

  course:Course;
  userName?:String;
  constructor(private courseService:CourseService, private router:Router) {
    this.course = new Course();
   }

  ngOnInit(): void {
    this.userName = localStorage.getItem("UserName")!;
  }
  AddCourse()
  {
    this.course.isAvailable = true;
    console.log(this.course);
    this.courseService.AddCourse(this.course).subscribe(res=>{
      if(res)
      {
        console.log("Course Added Successfully");
        Swal.fire(
          'Course Added Successfully',
          'Course Added Successfully!!!',
          'success'
        )
        this.router.navigate(['getallcourses']);
      }
      else 
      {
        console.log("Getting some Error to Add Course");
      }
    });
    
  }

}
