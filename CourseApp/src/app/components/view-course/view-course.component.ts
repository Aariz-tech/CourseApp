import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from 'src/app/models/course';
import { EnrollCourse } from 'src/app/models/enroll-course';
import { CourseService } from 'src/app/services/course.service';


@Component({
  selector: 'app-view-course',
  templateUrl: './view-course.component.html',
  styleUrls: ['./view-course.component.css']
})
export class ViewCourseComponent implements OnInit {

  courseData: Course;
  user?:String;
  
  constructor(private courseService:CourseService,private Activatedroute:ActivatedRoute,
    private router:Router) { 
    this.courseData = new Course();
  }

  ngOnInit(): void {

    
     this.fetchCourseData();
  }



  

  fetchCourseData()
  {
    this.user = localStorage.getItem("UserName")!;
    
    var courseName = this.Activatedroute.snapshot.queryParamMap.get('name')||null;
    this.courseService.getCourseByName(String(courseName)).subscribe(res=>{
      console.log(res);
      this.courseData = res;
    });
    
  }

}



