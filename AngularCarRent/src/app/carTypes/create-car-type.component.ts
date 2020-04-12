import { Component, OnInit } from '@angular/core';
import { CarType } from '../models/carType';
import { CarTypesService } from '../services/car-types.service';

@Component({
  selector: 'app-create-car-type',
  templateUrl: './create-car-type.component.html',
  styleUrls: ['./create-car-type.component.css']
})
export class CreateCarTypeComponent implements OnInit {
  cars: CarType[];

  car: CarType = {

    Manufacturer: null,
    Model: null,
    dailyCost: null,
    dailyLatePenalty: null,
    ManufacturingYear: null,
    GearType: null
  }
  


  constructor(private carsService: CarTypesService) { }



  ngOnInit() {
    
  }

  
  Create(car: CarType): void {


      console.log('created car type:' + car);
      this.carsService.CreateCarType(car).subscribe();
       

alert("car created");

        
      

  }


}

