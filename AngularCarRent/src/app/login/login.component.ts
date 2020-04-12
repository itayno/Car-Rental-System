import { Component, OnInit } from '@angular/core';    
import { Router } from '@angular/router';    
import { LoginService } from '../services/login.service';    
 import { FormsModule } from '@angular/forms';    
import { NavService } from '../services/nav.service';
import { UsersService } from '../services/users.service';
import { User } from '../models/User';
import { UserTypeEnum } from '../models/userTypeEnum';
import { approvedUser } from '../models/ApprovedUser';
    
@Component({    
  selector: 'app-login',    
  templateUrl: './login.component.html',    
  styleUrls: ['./login.component.css']    
})    
export class LoginComponent {    
  model : approvedUser = new approvedUser() ;
  //public credentials =  new credentials();    
    
  errorMessage:string;   
  userType: number; 

  constructor(private router:Router,private LoginService:LoginService,  
    private usersService: UsersService 
    ) {  }  
  ngOnInit() {
    this.model.userName="",this.model.userPassword="",this.model.userType=3
  }
  login(){    
    
    console.log('success login method');

    this.LoginService.Login(this.model).subscribe(
      data =>{
        if(data.Status=="success admin"){
          this.userType = 1;
          this.LoginService.login(this.model, this.userType, data.LoginUserId);
          //this.router.navigate(['/admin']);    

          console.log('success login admin');

        }
        else if(data.Status=="success user"){
          this.userType = 2;
          this.LoginService.login(this.model, this.userType, data.LoginUserId);
          //this.router.navigate(['/home']);    

          console.log('success login user');

        }
        else {
          this.userType = 3;
          this.LoginService.login(this.model, this.userType,  null);


          this.errorMessage = data.Message;  
        }
      },
      
        error => {    
          //debugger;
          this.errorMessage = error.message;    
        }); 
  }

  

  clickNotRgistered() {
    this.LoginService.login(this.model, 3, null);
          
  }

 }     