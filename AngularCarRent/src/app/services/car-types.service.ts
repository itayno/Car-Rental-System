import { Injectable } from '@angular/core';
import { map, tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { baseUrl } from 'src/environments/environment';
import { CarType } from '../models/carType';


@Injectable({
  providedIn: 'root'
})
export class CarTypesService {
  carTypes: CarType []=[] ;

  constructor(private http: HttpClient) { }

  getCarTypes (): Observable<CarType[]> {
    const urlCarTypes: string = 'CarType/find'; 

    return this.http.get<CarType[]>(baseUrl + urlCarTypes)
      .pipe(
        tap(_ => console.log('fetched car Types')) //,
        //catchError(this.handleError)
      );
      
  }
  deleteCarType (cartype: CarType ): Observable<CarType> {

    const urlCarTypes: string = 'CarType/delete/' + cartype.ID;

    return this.http.delete<CarType>(baseUrl + urlCarTypes).pipe(
      tap(_ => console.log(`deleted carType id=${cartype.ID}`)),
      //catchError(this.handleError<Car>('deleteHero'))
      );
  }

  updateCarType (cartype: CarType ): Observable<any> {
    const urlCarTypes:string = 'CarType/update/';
    return this.http.put<CarType>(baseUrl + urlCarTypes,cartype).pipe(
      tap(_ => console.log(`updated carType id=${cartype.ID}`)),
    );
  }

  CreateCarType (cartype: CarType): Observable<CarType> {

    const urlCarTypes: string = 'CarType/create/';
    
 

    return this.http.post<CarType>(baseUrl + urlCarTypes, cartype, {headers:{'Content-Type': 'application/json'}}).pipe(
      tap(_ => console.log(`created carType id=${cartype.ID}`))
    );

    
  }

  handleError(): any { console.log("error");}
  
}

