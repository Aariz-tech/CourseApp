import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

    userName?:String;
  constructor(private breakpointObserver: BreakpointObserver,private router:Router) {}

  loggedIn()
  {
    this.userName = localStorage.getItem("UserName")!;
    let userNameExists = localStorage.getItem("UserName");
    if(userNameExists)
    {
      return true;
    }
    else {
      return false;
    }
  }

  getAdmin()
  {
    var userName = localStorage.getItem('UserName')
    if(userName == "admin")
    {
      
      return true;
    }
    else 
    {
      return false;
    }
  }

}
