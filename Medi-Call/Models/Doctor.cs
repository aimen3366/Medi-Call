//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Medi_Call.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Doctor
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirm_Pssword { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public Nullable<int> Contact_No { get; set; }
        public string Location { get; set; }
        public Nullable<int> Fee_Status { get; set; }
        public string Working_Days { get; set; }
        public string Timings { get; set; }
    }
}
