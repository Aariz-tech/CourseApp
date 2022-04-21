import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  user:User;
  constructor(private userService:UserService, private router:Router) {
    this.user = new User();
   }

  ngOnInit(): void {
  }

  registerUser() {
    console.log(this.user);

    this.user.isBlocked=false;
    
    
    
    this.userService.registerUser(this.user).subscribe(res=>{
      if(res)
      {
        console.log("Registration Success");
        Swal.fire(
          'Register Success',
          'Registration Successfull!!!',
          'success'
        )
        this.router.navigate(['login']);
      }
      else 
      {
        console.log("Registration Failed");
      }
    });


}
}
