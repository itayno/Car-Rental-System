import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../models/orders';
import { HttpClient } from '@angular/common/http';
import { baseUrl } from 'src/environments/environment';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  constructor(private http: HttpClient) { }

  getOrders (): Observable<Order[]> {
    const urlCarRentalDetails: string = 'carrentaldetail/find'; 

    return this.http.get<Order[]>(baseUrl + urlCarRentalDetails)
      .pipe(
        tap(_ => console.log('fetched orders')) //,
        //catchError(this.handleError)
      );
      
  }
  deleteOrder (orders: Order ): Observable<Order> {

    const urlCarRentalDetails: string = 'carrentaldetail/delete/' + orders.id;

    return this.http.delete<Order>(baseUrl + urlCarRentalDetails).pipe(
      tap(_ => console.log(`deleted order id=${orders.id}`)),
      //catchError(this.handleError<Car>('deleteHero'))
      );
  }

  updateOrder (orders: Order ): Observable<any> {
    const urlCarRentalDetails:string = 'carrentaldetail/update/';
    return this.http.put<Order>(baseUrl + urlCarRentalDetails,orders).pipe(
      tap(_ => console.log(`updated order id=${orders.id}`)),
    );
  }

  createOrder (orders: Order): Observable<Order> {

    const urlCarRentalDetails: string = 'carrentaldetail/create/';
    
 

    return this.http.post<Order>(baseUrl + urlCarRentalDetails, orders, {headers:{'Content-Type': 'application/json'}}).pipe(
      tap(_ => console.log(`created order id=${orders.id}`))
    );

    
  }

  handleError(): any { console.log("error");}
}