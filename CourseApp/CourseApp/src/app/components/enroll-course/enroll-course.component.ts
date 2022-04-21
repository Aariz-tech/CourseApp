import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EnrollCourse } from 'src/app/models/enroll-course';
import { CourseService } from 'src/app/services/course.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-enroll-course',
  templateUrl: './enroll-course.component.html',
  styleUrls: ['./enroll-course.component.css']
})
export class EnrollCourseComponent implements OnInit {

  enrollCourseByUserName?:Array<EnrollCourse>;
  constructor(private courseService:CourseService, private router:Router) {
    
   }
  
  ngOnInit(): void {
    var userName = localStorage.getItem('UserName');
    
    console.log(userName)
    userName = String(userName);
    this.courseService.enrolledCourseByUserName(userName).subscribe(res=>{
      console.log(res);
      this.enrollCourseByUserName = res;
    });
  }
  viewCourse(course)
  {
    console.log(course)
    this.router.navigate(['/view-course'], { queryParams: { name: course.name } }); 
  }
  cancelCourse(course)
  {
    console.log(course.id)
    this.courseService.cancelCourse(course.id).subscribe(res=>{
      console.log(res);
      Swal.fire(
        'Cancel Course',
        'cancellation Success',
        'success'
      )
      
      window.location.reload();
      
      
    });
    
  }
  
}
