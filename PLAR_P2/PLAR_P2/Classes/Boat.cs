// Name: Aaron Chambers
// Date: 2020-18-20
// Description:
//      This file is the model for the boat object
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAR_P2.Classes
{
    public class Boat:Vehicle
    {
        /// <summary>
        /// Creates a new boat object
        /// </summary>
        /// <param name="manufacturer">The manufacturer of the boat</param>
        /// <param name="model">The model of the boat</param>
        /// <param name="productYear">The product year of the boat</param>
        public Boat(string manufacturer, string model, string productYear): base( manufacturer,  model, productYear)
        {
           
        }
    }
}
