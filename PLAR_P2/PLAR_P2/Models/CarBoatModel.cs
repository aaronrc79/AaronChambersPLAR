using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpressiveAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PLAR_P2.Models
{
    public class CarBoatModel
    {
        /// <summary>
        /// The manufacturer of the vehicle: String
        ///     Required
        ///     No Empty string
        ///     Display Name: Manufacturer
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The vehicle must have a manufacturer")]
        [Display(Name = "Manufacturer")]
        public string manufacturer { get; set; }

        /// <summary>
        /// The model of the vehicle: String
        ///     Required
        ///     No Empty string
        ///     Display Name: Model
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The vehicle must have a Model")]
        [Display(Name = "Model")]
        public string model { get; set; }

        /// <summary>
        /// The product year of the vehicle: Int
        ///     Required
        ///     Min: 1885
        ///     Max: 9999
        ///     Display Name: Product Year
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The vehicle must have a model"), Range(1885, 9999, ErrorMessage = "The vehicle year must be between 1885 and 9999.")]
        [Display(Name = "Product Year")]
        public int productYear { get; set; }


        /// <summary>
        /// The product year of the vehicle: Double
        ///     Min: 0
        ///     Display Name: Mileage
        /// </summary>
        [Display(Name = "Mileage")]
        [Range(0, double.MaxValue, ErrorMessage = "The mileage must be greater than 0")]
        public double? mileage { get; set; }


    }
}
