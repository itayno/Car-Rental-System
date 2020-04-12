using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarWebAPI.Models;

namespace CarWebAPI.Parsing
{
    public class BranchParsing
    {
        public static BranchEntity typeObjector(Branch branch)
        {
            BranchEntity branchObject = new BranchEntity();

            branchObject.Branchaddress = branch.BranchAddress;
            branchObject.BranchName = branch.BranchName;
            branchObject.id = branch.id;
            branchObject.LattitudeX = int.Parse(branch.LatitudeX.ToString());
            branchObject.LongttitudeY = int.Parse(branch.LongitudeY.ToString());

            return branchObject;


        }
    }
}