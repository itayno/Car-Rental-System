
import { Injectable } from "@angular/core";
import { UserTypeEnum } from '../models/userTypeEnum';
import {approvedUser} from '../models/ApprovedUser';

@Injectable()
export class UserAuthentication {

  
  GetBase64(): any {
    var user = this.getCurrentUser();
    return window.btoa(user.userName + ":" + user.userPassword);
  }

    static ManagerGuard: any;


  getCurrentUser(): approvedUser {
    
    var user = localStorage["user"];
    console.log("getCurrentUser:" + user    );


    if (user) {
      var userData: approvedUser = JSON.parse(user);
    }

    return userData;
  }

  get UserType(): UserTypeEnum {
    let user: approvedUser = this.getCurrentUser();
    if (user) {
      return user.userType;
    }
    return UserTypeEnum.Unknown;
  }

  login(user: approvedUser) {
    localStorage.setItem("user", JSON.stringify(user));
  }

  logout() {
    localStorage.removeItem("user");
  }

}
