import { Injectable } from '@angular/core';
import { Car } from '../models/car';
import { map, tap, catchError, distinct } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { baseUrl } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CarsService {
  car: Car []=[] ;
  carToRent: Car;
  carToEdit: Car;

  
  constructor(private http: HttpClient) {}

  getCars (): Observable<Car[]> {
    const urlCar: string = 'car/find'; 

    return this.http.get<Car[]>(baseUrl + urlCar)
      .pipe(
        tap(_ => console.log('fetched cars')) //,
        //catchError(this.handleError)
      );
      
  }

  getByID (carNumber: string): Observable<Car[]> {
    const urlCar: string = 'car/findById'; 

    return this.http.get<Car[]>(baseUrl + urlCar + carNumber)
      .pipe(
        tap(_ => console.log('fetched cars')) //,
        //catchError(this.handleError)
      );
      
  }

  deleteCar (cars: Car ): Observable<Car> {

    const urlCar: string = 'car/delete/' + cars.CarNumber;

    return this.http.delete<Car>(baseUrl + urlCar).pipe(
      tap(_ => console.log(`deleted car number=${cars.CarNumber}`)),
      //catchError(this.handleError<Car>('deleteHero'))
      );
  }

  updateCar (cars: Car ): Observable<any> {
    const urlCar:string = 'car/update/';
    return this.http.put<Car>(baseUrl + urlCar,cars).pipe(
      tap(_ => console.log(`updated car number=${cars.CarNumber}`)),
    );
  }
  updateIsAvailableById (carNumber: string): Observable<any> {
    // debugger;
 
     const urlCars: string = 'cars/updateAvailable/';
 
     return this.http.put(baseUrl + urlCars + carNumber, carNumber).pipe(
       tap(_ => console.log(`updated care number=${carNumber}`))
     );
   }

  CreateCar (cars: Car): Observable<Car> {

    const urlCar: string = 'car/create/';
    
 

    return this.http.post<Car>(baseUrl + urlCar, cars, {headers:{'Content-Type': 'application/json'}}).pipe(
      tap(_ => console.log(`created car number=${cars.CarNumber}`))
    );

    
  }

  handleError(): any { console.log("error");}
}

