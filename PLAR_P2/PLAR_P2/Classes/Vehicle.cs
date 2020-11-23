// Name: Aaron Chambers
// Date: 2020-18-20
// Description:
//      This file is the model for the base Vehicle object.
//      Each object stores the Manufacturer, Model and Product Year.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAR_P2.Classes
{

    public class Vehicle
    {
        #region "Variable Declaration"

        private string manufacturer;
        private string model;
        private int productYear;

        #endregion
        #region "Constructors"
        /// <summary>
        /// Vehicle: Accepts a manufacturer, model and product year, validates the entered values.
        /// </summary>
        /// <param name="manufacturer">The manufacturer of the car</param>
        /// <param name="model">The model of the car</param>
        /// <param name="productYear">The product year of the car</param>
        public Vehicle(string manufacturer, string model, string productYear)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.ProductYear = productYear;
        }
        #endregion

        #region "Property Procedures"
        /// <summary>
        /// Gets and sets the Manufacturer of the vehicle
        /// </summary>
        /// <returns>The vehicle Manufacturer</returns>
        internal string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (value.Trim() != String.Empty)
                {
                    this.manufacturer = value;
                }else
                {
                    throw new ArgumentException("You must enter a manufacturer.", "Manufacturer");
                }
            }
        }
        /// <summary>
        /// Gets and sets the model of the vehicle
        /// </summary>
        /// <returns>The vehicle model</returns>
        internal string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (value.Trim() != String.Empty)
                {
                    this.model = value;
                }
                else
                {
                    throw new ArgumentException("You must enter a model.", "Model");
                }
            }
        }
        /// <summary>
        /// Gets and sets the product year of the vehicle
        /// </summary>
        internal string ProductYear
        {
            get
            {
                return this.productYear.ToString();
            }
            set
            {
                    if (!int.TryParse(value, out this.productYear))
                    {
                        // Value was not a whole number; report as an error.
                        throw new ArgumentException("You must enter the product year as a number.", "ProductYear");

                    }
                    // If the stored value is not a positive number, report an error.
                    else if (this.productYear < 1885 || this.productYear > 9999)
                    {
                        throw new ArgumentOutOfRangeException("ProductYear", "The product year must be a a whole number between 1885 and 9999");
                    }
                }
            }
        #endregion


    }
}
