import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginUser } from '../models/login-user';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  

  constructor(private httpClient:HttpClient) {

   }
  loginUser(loginUser:LoginUser):Observable<string> {
    return this.httpClient.post<string>('https://localhost:5003/api/User/loginUser',loginUser)
  }
  registerUser(user:User):Observable<boolean> {
    return this.httpClient.post<boolean>('https://localhost:5003/api/User/registerUser',user)
  }


}
