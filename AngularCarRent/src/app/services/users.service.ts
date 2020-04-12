import { Injectable } from '@angular/core';
import { map, tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TagContentType } from '@angular/compiler';
import { User } from '../models/user';
import { baseUrl } from 'src/environments/environment';
import { UserName } from '../models/userName';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  //car: User []=[] ;
  formData: User;


  constructor(private http: HttpClient) { }

  getUsers (): Observable<User[]> {
    const urlUsers: string = 'user/find'; 

    return this.http.get<User[]>(baseUrl + urlUsers)
      .pipe(
        tap(_ => console.log('fetched users')) //,
        //catchError(this.handleError)
      );
      
  }

  deleteUser (user: User ): Observable<User> {

    const urlUsers: string = 'user/delete/' + user.ID;

    return this.http.delete<User>(baseUrl + urlUsers).pipe(
      tap(_ => console.log(`deleted user id=${user.ID}`)),
      //catchError(this.handleError<Car>('deleteHero'))
      );
  }

  updateUser (user: User ): Observable<any> {
    const urlUsers:string = 'user/update/';
    return this.http.put<User>(baseUrl + urlUsers,user).pipe(
      tap(_ => console.log(`updated user id=${user.ID}`)),
    );
  }

  CreateUser (user: User): Observable<User> {

    const urlUsers: string = 'users/create/';
    
 

    return this.http.post<User>(baseUrl + urlUsers, user, {headers:{'Content-Type': 'application/json'}}).pipe(
      tap(_ => console.log(`created user id=${user.FirstName}`))
    );

    
  }

  handleError(): any { console.log("error");}
  




}
