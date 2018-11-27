using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Medi_Call.Models
{
    public class DoctorRegisterViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "minimum 6 characters required")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string Confirm_Password { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Name { get; set; }

       
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Speciality { get; set; }


        [DisplayName("Contact No")]
        [DataType(DataType.PhoneNumber)]     
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public int Contact_No { get; set; }

        
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Location { get; set; }


        [DisplayName("Fee Status")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public int Fee_Status { get; set; }

        [DisplayName("Working Days")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Working_Days { get; set; }

  
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Timings { get; set; }

    }
}