import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Course } from '../models/course';
import { EnrollCourse } from '../models/enroll-course';
import { Logincourse } from '../models/logincourse';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private httpClient:HttpClient) { }
  getAllCourses():Observable<Array<Course>>
  {
    return this.httpClient.get<Array<Course>>('https://localhost:5018/api/Course/getAllCourses');

  }
  loginCourse(logincourse:Logincourse):Observable<boolean> {
    return this.httpClient.post<boolean>('https://localhost:5018/api/Course/loginCourse',logincourse)
  }
  enrolledMyCourse(enrollCourse:EnrollCourse):Observable<boolean>
  {
    return this.httpClient.post<boolean>('https://localhost:5001/api/EnrollCourse/enrollCourse',enrollCourse)
  }


}
