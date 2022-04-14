import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Course } from '../models/course';
import { EnrollCourse } from '../models/enroll-course';


@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private httpClient:HttpClient) { }
  getAllCourses():Observable<Array<Course>>
  {
    return this.httpClient.get<Array<Course>>('https://localhost:5018/api/Course/getAllCourses');

  }
  
  enrolledMyCourse(enrollCourse:EnrollCourse):Observable<boolean>
  {
    return this.httpClient.post<boolean>('https://localhost:5001/api/EnrollCourse/enrollCourse',enrollCourse)
  }
 

  enrolledCourseByUserName(userName:string):Observable<Array<EnrollCourse>>
  {
    return this.httpClient.get<Array<EnrollCourse>>('https://localhost:5001/api/EnrollCourse/getAllEnrolledCourseByName?username='+userName);
  }

  getCourseByName(courseName:String):Observable<Course>
  {
    return this.httpClient.get<Course>('https://localhost:5018/api/Course/getCourseByName?courseName='+courseName);
  }


}
