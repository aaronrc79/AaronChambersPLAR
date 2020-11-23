// Name: Aaron Chambers
// Date: 2020-18-20
// Description:
//      This file is the model that we will use to assign the extracted 
//      rows from the database. 
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PLAR_P2.Models
{
    public class VehicleDBO
    {
       
        public string id { get; set; }
        public string manufacturer { get; set; }

        public string model { get; set; }
        
        public string productYear { get; set; }
        public string mileage { get; set; }
        public bool isCar { get; set; }
    }
}
