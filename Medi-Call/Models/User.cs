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
    
    public partial class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirm_Password { get; set; }
        public string Secret_Question { get; set; }
        public string Answer { get; set; }
    }
}
