import { CarType } from './carType';
import { branch } from './branch';

export class Car {
    CarNumber?: string;
    CarType?: number;
    BranchID?: number;
    imagePath?: string;
    IsAvailable?: boolean;
    IsUndamaged?: boolean;
    Mileage?: number;
    carTypeObject?: CarType;
    branchObject?: branch;
    image?:any;
    
//
   
}
