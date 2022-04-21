import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from 'src/app/models/course';
import { CourseService } from 'src/app/services/course.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-update-course',
  templateUrl: './update-course.component.html',
  styleUrls: ['./update-course.component.css']
})
export class UpdateCourseComponent implements OnInit {

  courseData:Course;
  courseId?:Number;

  constructor(private courseService:CourseService,private router:Router,private Activatedroute:ActivatedRoute) { 
    this.courseData = new Course();
  }

  ngOnInit(): void {
    var courseId = this.Activatedroute.snapshot.queryParamMap.get('id')||null;
    this.courseId = Number(courseId);
    this.courseService.getCourseById(Number(courseId)).subscribe(res=>{
      if(res)
      {
        this.courseData = res;
        console.log(this.courseData);
        
      }
      else
      {
        console.log("Getting Some Error");
        
      }
    })
  }
  update(course)
  {
    this.courseService.updateCourse(Number(this.courseId),course).subscribe(res=>{
      if(res)
      {
        console.log("Course Updated");
        Swal.fire(
          'Course Updation Success',
          'Updation Successfull!!!',
          'success'
        )
        this.router.navigate(['getallcourses']);
      }
      else 
      {
        console.log("Getting Some Error in Update course");
        
      }
    })
  }

}
