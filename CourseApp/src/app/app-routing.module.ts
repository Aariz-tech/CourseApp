import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { EnrollcourseComponent } from './components/enrollcourse/enrollcourse.component';

import { GetallcoursesComponent } from './components/getallcourses/getallcourses.component';

import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { RegisterComponent } from './components/register/register.component';

const routes: Routes = [
  {path:'register',component:RegisterComponent},
  {path:'login',component:LoginComponent},
  {path:'logout',component:LogoutComponent,canActivate:[AuthGuard]},
  {path:'getallcourses',component:GetallcoursesComponent,canActivate:[AuthGuard]},
  {path:'enrollcourse',component:EnrollcourseComponent,canActivate:[AuthGuard]},
  
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
