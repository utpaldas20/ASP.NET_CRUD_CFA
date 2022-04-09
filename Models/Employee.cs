using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_CODE_FIRST.Models
{
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }

      //  [Required(ErrorMessage ="Email is requires !!!")]
        public string Email { get; set; }

     //    [Required(ErrorMessage = "Address is requires !!!")]
        public string Address { get; set; }

     //   [Required(ErrorMessage = "Phone No. is requires !!!")]
        public string Phone { get; set; }
    }
}