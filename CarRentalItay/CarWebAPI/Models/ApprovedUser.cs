using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarWebAPI.Models
{
    public class ApprovedUser
    {
        [Required(ErrorMessage = "no username")]
        public string userName { get; set; }

        [Required(ErrorMessage = "no password")]
        public string userPassword { get; set; }


        public string role { get; set; }
    }
}