using EmployeeMngWebApp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeMngWebApp.Models
{
    public class Extra_Info_About_Emp
    {
        [Required(ErrorMessage = "No is must")]
        [Range(1, 100, ErrorMessage = "No must be between 1 to 100")]
        public int No { get; set; }

        [LoginValidator(ErrorMessage = "1234 is not a valid Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Address is must")]
        public string Address { get; set; }
    }
}