import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { EnrollCourseComponent } from './components/enroll-course/enroll-course.component';

import { GetallcoursesComponent } from './components/getallcourses/getallcourses.component';
import { HomeComponent } from './components/home/home.component';

import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { RegisterComponent } from './components/register/register.component';
import { ViewCourseComponent } from './components/view-course/view-course.component';

const routes: Routes = [
  {path:'register',component:RegisterComponent},
  {path:'login',component:LoginComponent},
  {path:'logout',component:LogoutComponent,canActivate:[AuthGuard]},
  {path:'getallcourses',component:GetallcoursesComponent,canActivate:[AuthGuard]},
  {path:'',component:HomeComponent},
  {path:'enrollcourses',component:EnrollCourseComponent,canActivate:[AuthGuard]},
  {path:'view-course',component:ViewCourseComponent,canActivate:[AuthGuard]},
  { path: 'view-course/:courseName', component: ViewCourseComponent,canActivate:[AuthGuard] },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
