import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';

import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { LogoutComponent } from './components/logout/logout.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './components/nav/nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { CarouselComponent } from './components/carousel/carousel.component';

import {MatCardModule} from '@angular/material/card';
import { GetallcoursesComponent } from './components/getallcourses/getallcourses.component';
import { FooterComponent } from './components/footer/footer.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { ServiceSectionComponent } from './components/service-section/service-section.component';
import { HomeComponent } from './components/home/home.component';
import { EnrollCourseComponent } from './components/enroll-course/enroll-course.component';
import { ViewCourseComponent } from './components/view-course/view-course.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { RatingModule } from 'ngx-bootstrap/rating';
import { AddCourseComponent } from './components/add-course/add-course.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import { UpdateCourseComponent } from './components/update-course/update-course.component';
import {MatInputModule} from '@angular/material/input';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    RegisterComponent,
    LogoutComponent,
    NavComponent,
    CarouselComponent,
    GetallcoursesComponent,
    FooterComponent,
    
    ServiceSectionComponent,
         HomeComponent,
         EnrollCourseComponent,
         ViewCourseComponent,
         AddCourseComponent,
         UpdateCourseComponent,
         
         
         
    
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatCardModule,
    HttpClientModule,
    FormsModule,
    CarouselModule.forRoot(),
    AccordionModule.forRoot(),
    RatingModule.forRoot(),
    MatFormFieldModule,
    MatInputModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
