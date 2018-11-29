using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Medi_Call.Models
{
    public class BloodViewModel
    {
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [DisplayName("Contact")]
        [DataType(DataType.PhoneNumber)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public int Contact { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Location { get; set; }


        [DisplayName("Blood Group")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Blood_Group { get; set; }
    }
}