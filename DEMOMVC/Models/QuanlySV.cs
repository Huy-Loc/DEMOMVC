using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEMOMVC.Models
{
    public class QuanlySV : Student
    {
        public string Address { get; set; }
        [AllowHtml]
        public string Comment { get; set; }
    }
}