import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginUser } from 'src/app/models/login-user';
import { UserService } from 'src/app/services/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginUser:LoginUser;
  constructor(private userService:UserService,private router:Router) { 
    this.loginUser = new LoginUser();
  }

  ngOnInit(): void {
  }
  userLogin(loginFormRef:NgForm)
  {
    this.loginUser = loginFormRef.value;
    console.log(this.loginUser);
    
    if(this.loginUser.userName == "admin")
    {
      this.userService.loginUser(this.loginUser).subscribe(res=>{
      
        let jsonObject = JSON.stringify(res);
        let jsonToken=JSON.parse(jsonObject);
        console.log(`User Token After Login ::: ${jsonToken["Token"]}`);
        localStorage.setItem('UserTOKEN',jsonToken["Token"]);
        localStorage.setItem('UserName',jsonToken["UserName"]);
        localStorage.setItem('UserEmail',jsonToken["Email"]);
        Swal.fire(
          'Welcome Admin',
          'Login Success',
          'success'
        )
        this.router.navigate(['add-course']);
        
      });
    }

    else 
    {
    this.userService.loginUser(this.loginUser).subscribe(res=>{
      
      let jsonObject = JSON.stringify(res);
      let jsonToken=JSON.parse(jsonObject);
      console.log(`User Token After Login ::: ${jsonToken["Token"]}`);
      localStorage.setItem('UserTOKEN',jsonToken["Token"]);
      localStorage.setItem('UserName',jsonToken["UserName"]);
      localStorage.setItem('UserEmail',jsonToken["Email"]);
      Swal.fire(
        'Login User',
        'Login Success',
        'success'
      )
      this.router.navigate(['getallcourses']);
      
    });
  }
  }


}
