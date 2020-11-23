using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace PLAR_P2.Models
{
    public class CarModel : VehicleModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The vehicle must have mileage"), Range(0, double.MaxValue, ErrorMessage = "The mileage must be greater than 0")]
        [Display(Name = "Mileage")]
        public double mileage { get; set; }


    }
}
