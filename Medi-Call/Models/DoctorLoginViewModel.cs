using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Medi_Call.Models
{
    public class DoctorLoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}