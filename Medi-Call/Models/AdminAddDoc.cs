using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Medi_Call.Models
{
    public class AdminAddDoc
    { 

        
        public string Name { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Speciality { get; set; }


        [DisplayName("Contact No")]
        
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