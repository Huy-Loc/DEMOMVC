using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DEMOMVC.Models
{
    public class Account
    {   
        [Key]
        [Required(ErrorMessage ="Tên đăng nhập không được để trống")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(10)]
        public string RoleID { get; set; }
    }
}