import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Course } from 'src/app/models/course';
import { EnrollCourse } from 'src/app/models/enroll-course';
import { Logincourse } from 'src/app/models/logincourse';

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
  
  }
    


  
