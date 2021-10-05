using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEMOMVC.Areas.Employees.Controllers
{
    [Authorize(Roles ="NV")]
    public class HomeEmpController : Controller
    {
        // GET: Employees/HomeEmp
        public ActionResult Index()
        {
            return View();
        }
    }
}