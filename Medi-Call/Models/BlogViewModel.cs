using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Medi_Call.Models
{
    public class BlogViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Paragraph { get; set; }

        public string Uploaded_By { get; set; }
    }
}