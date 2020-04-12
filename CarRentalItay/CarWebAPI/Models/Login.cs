using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWebAPI.Models
{
    public class Login
    {
        public string userName { get; set; }
        public string userPassword { get; set; }
        public int userID { get; set; }
    }
    public class Registration : User { }
}