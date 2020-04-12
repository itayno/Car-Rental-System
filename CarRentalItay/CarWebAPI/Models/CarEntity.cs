using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWebAPI.Models
{
    public class CarEntity
    {
        public string carNumber { get; set; }
        public int carType { get; set; }
        public string imagePath { get; set; }
        public Boolean isAvailable { get; set; }
        public Boolean isUndamaged { get; set; }
        public int branchId { get; set; }
        public int mileage { get; set; }
        public Byte[] image { get; set; }
        public CarTypeEntity carTypeObject { get; set; }
        public BranchEntity branchObject { get; set; }
    }
}