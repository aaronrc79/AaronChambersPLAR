using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PLAR_P2.Models

{

    //properties including “Manufacturer”, “Model”, and “Product Year”. 



    public class VehicleModel
    {
        #region "Variable Declaration"

        [Required(AllowEmptyStrings =false, ErrorMessage ="The vehicle must have a manufacturer")]
        [Display(Name = "Manufacturer")]
        public string manufacturer { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The vehicle must have a manufacturer")]
        [Display(Name = "Model")]
        public string model { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The vehicle must have a model"), Range(1885, 9999, ErrorMessage = "The vehicle year must be between 1885 and 9999.")]
        [Display(Name ="Product Year")]
        public int productYear { get; set; }

        #endregion




    }
}
