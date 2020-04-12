using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWebAPI.Models
{
    public class BranchEntity
    {
        public int id { get; set; }
        public string BranchName { get; set; }
        public string Branchaddress { get; set; }
        public int LattitudeX { get; set; }
        public int LongttitudeY { get; set; }
    }
}