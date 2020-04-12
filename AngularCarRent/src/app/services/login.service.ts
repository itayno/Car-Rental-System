import { Injectable } from '@angular/core';  
import {HttpClient, HttpBackend} from '@angular/common/http';  
import {HttpHeaders} from '@angular/common/http';  
import { from, Observable } from 'rxjs';  
import { User } from '../models/user';
import { UserTypeEnum } from '../models/userTypeEnum';
import { tap } from 'rxjs/operators';
import { baseUrl } from 'src/environments/environment';
import { approvedUser } from 'src/app/models/ApprovedUser';
@Injectable({  
  providedIn: 'root'  
})  
export class LoginService {  
  Url :string;  
  token : string;  
  header : any;  

  constructor(private http : HttpClient, handler: HttpBackend) {   
    this.http = new HttpClient(handler);
    this.Url = baseUrl + 'Login/';  
  
    const headerSettings: {   [name: string]: string | string[]; } = {};  
    this.header = new HttpHeaders(headerSettings);  
  }  
  Login(model : approvedUser){
    return this.http.post<any>(this.Url+'UserLogin',model,{ headers: this.header})
  }
  LoginRefactor(approvedUser : approvedUser): Observable<User>  {

    return this.http.post<User>(this.Url+'login', approvedUser);



  }
  getCurrentUser(): User {
    
    var user = localStorage["user"];

    if (user) {
      var userData: User = JSON.parse(user);
    }

    return userData;
  }
  GetBase64(): any {
    var user = this.getCurrentUser();
    return window.btoa(user.UserName + ":" + user.UserPassword);
  }

    static ManagerGuard: any;
    login(userData: approvedUser, userType: number, userId: number) {
      userData.userType = userType;
      userData.userId = userId;
      console.log("local stroage set");
  
      localStorage.setItem("user", JSON.stringify(userData));
    }
  
    logout() {
      localStorage.removeItem("user");
    }
 
}  