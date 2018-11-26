using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Medi_Call.Models
{
    public class UserRegisterViewModel
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


        [DisplayName("Secret Question")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Secret_Question { get; set; }


        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Answer { get; set; }
    }
}