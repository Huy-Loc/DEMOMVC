using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DEMOMVC.Models;

namespace DEMOMVC.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        Encrytion encry = new Encrytion();
        LapTrinhQuanLyDBcontext db = new LapTrinhQuanLyDBcontext();
        StringProcess strPro = new StringProcess(); 

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(Account acc)
        {
            if (ModelState.IsValid)
            {
                acc.Password = encry.PasswordEncrytion(acc.Password);
                db.Accounts.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            return View(acc);
        }
        [HttpGet]

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            FormsAuthentication.SignOut();
            Session["idUser"] = null;
            //if (CheckSession() ==1)
            //{
            //    return RedirectToAction("Index", "HomeAdmin", new { Area = "Admins" });
            //}
            //else if (CheckSession() == 2)
            //{
            //    return RedirectToAction("Index", "HomeEmp", new { Area = "Employees" });
            //}
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Account acc, string returnUrl)
        {
            try
            {
                if(!string.IsNullOrEmpty(acc.UserName) && !String.IsNullOrEmpty(acc.Password))
                {
                    using (var db = new LapTrinhQuanLyDBcontext())
                    {
                        var passToMD5 = strPro.GetMD5(acc.Password);
                        var account = db.Accounts.Where(m => m.UserName.Equals(acc.UserName) && m.Password.Equals(passToMD5)).Count();
                        if (account == 1)
                        {
                            FormsAuthentication.SetAuthCookie(acc.UserName, false);
                            Session["idUser"] = acc.UserName;
                            Session["roleUser"] = acc.RoleID;
                            return RedirectToLocal(returnUrl);

                        }
                        ModelState.AddModelError("", "Thông Tin Đăng Nhập Chưa Chính Xác");
                    }
                }
                ModelState.AddModelError("", "Username and Password is require.");
            }
            catch
            {
                ModelState.AddModelError("", "Hệ thống đang bảo trì, vui lòng liên hệ với quản trị viên");
            }
            return View(acc);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["idUser"] = null;
            return RedirectToAction("Login", "Account");
        }
        //kiem tra nguoi dung dang nhap voi quyen gi
        private int CheckSession()
        {
            using (var db = new LapTrinhQuanLyDBcontext())
            {
                var user = HttpContext.Session["idUser"];
                if (user != null)
                {
                    var role = db.Accounts.Find(user.ToString()).RoleID;
                    if (role != null)
                    {
                        if (role.ToString() == "Admin")
                        {
                            return 1;
                        }
                        else if (role.ToString() == "NV")
                        {
                            return 2;
                        }

                    }

                }

            }

            return 0;
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
            {
                if (CheckSession() == 1)
                {
                    return RedirectToAction("Index", "HomeAdmin", new { Area = "Admins" });
                }
                else if (CheckSession() == 2)
                {
                    return RedirectToAction("Index", "HomeEmp", new { Area = "Employees" });
                }
            }
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);

            }

            else
            { return RedirectToAction("Index", "Home"); }
        }
    }
}