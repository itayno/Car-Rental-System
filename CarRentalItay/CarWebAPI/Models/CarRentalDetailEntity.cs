﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWebAPI.Models
{
    public class CarRentalDetailEntity
    {
        public int id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime returnDate { get; set; }
        public DateTime actualReturnDate { get; set; }
        public int userId { get; set; }
        public string carNumber { get; set; }
        public Boolean isActive { get; set; }
    }
}