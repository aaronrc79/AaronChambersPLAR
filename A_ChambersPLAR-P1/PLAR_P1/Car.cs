// Name: Aaron Chambers
// Date: 2020-18-20
// Description:
//      This file is the model for the car object.
//      Each object is based of a Vehicle object and in addition to
//      the properties and variables of the vehicle class the Car object adds
//      the mileage property
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAR_P1
{
    class Car: Vehicle
    {
        #region "Variable Declaration"
        private decimal mileage;
        #endregion


        #region "Constructors"
        /// <summary>
        /// Declaration of the Car object
        /// </summary>
        /// <param name="manufacturer">The manufacturer of the car</param>
        /// <param name="model">The model of the car</param>
        /// <param name="productYear">The product year of the car</param>
        /// <param name="mileage">The mileage of the car</param>
        public Car(string manufacturer, string model, string productYear, string mileage): base(manufacturer, model, productYear)
        {
            this.Mileage = mileage;
            
        }
        #endregion

        #region "Property Procedures"

        /// <summary>
        /// Gets and sets the mileage of the car
        /// </summary>
        internal string Mileage
        {
            get
            {
                return this.mileage.ToString();
            }
            set
            {
                if (!decimal.TryParse(value, out this.mileage))
                {
                    // Value was not a whole number; report as an error.
                    throw new ArgumentException("You must enter the mileage as a number.", "Mileage");

                }
                // If the stored value is not a positive number, report an error.
                else if (this.mileage < 0)
                {
                    throw new ArgumentOutOfRangeException("Mileage", "The mileage must be a positive number");
                }
            }
        }
        #endregion

    }
}
