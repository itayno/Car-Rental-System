using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWebAPI.Models
{
    public class CarTypeEntity
    {
        public int id { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public double dailyCost { get; set; }
        public double dailyLatePenalty { get; set; }
        public DateTime manufacturingYear { get; set; }
        public string gearType { get; set; }
    }
}