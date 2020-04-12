import { Component, OnInit } from '@angular/core';
import { Car } from '../models/car';
import { CarsService } from '../services/car.service';
import { createNgModuleRef } from '@angular/core/src/view/refs';

@Component({
  selector: 'app-edit-car',
  templateUrl: './edit-car.component.html',
  styleUrls: ['./edit-car.component.css']
})
export class EditCarComponent implements OnInit {
 car: Car = {
  CarNumber: null,
  CarType: null,
  imagePath: null,
  IsAvailable: null,
  IsUndamaged: null,
  Mileage: null
  }
  
    


 
  
  constructor(private carSerivce: CarsService ) { this.car = this.carSerivce.carToRent ; }

  ngOnInit() {
    //this.car = this.carSerivce.carToRent;
  }

  ngBeforeViewInit() {
    this.car = this.carSerivce.carToRent;
    
//
  }

EditCar(car: Car) {

  this.carSerivce.updateCar(car).subscribe();


}

}
//