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
        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirm_Pssword { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public int Contact_No { get; set; }
        public string Location { get; set; }
        public int Fee_Status { get; set; }
        public string Working_Days { get; set; }
        public string Timings { get; set; }

    }
}