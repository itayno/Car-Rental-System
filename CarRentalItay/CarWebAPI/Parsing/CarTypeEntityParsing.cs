using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarWebAPI.Models;


namespace CarWebAPI.Parsing
{
    public class CarTypeEntityParsing
    {
        public static CarTypeEntity typeObjector(CarType typeCar)
        {
            CarTypeEntity carTypeObject = new CarTypeEntity();
             
            carTypeObject.manufacturer = typeCar.Manufacturer;
            carTypeObject.model = typeCar.Model;
            carTypeObject.dailyCost = typeCar.DailyCost;
            carTypeObject.dailyLatePenalty = typeCar.DailyLatePenalty;
            carTypeObject.gearType = typeCar.GearType;
            carTypeObject.manufacturingYear = typeCar.ManufacturingYear;

            return carTypeObject;


        }

    }
}