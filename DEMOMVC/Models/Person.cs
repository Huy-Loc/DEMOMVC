using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DEMOMVC.Models
{
    public class Person
    {
        public string PersonID { get; set; }
        [Required(ErrorMessage = "ID không được để trống")]
        public string PersonName { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [MinLength(3)]
    }
}