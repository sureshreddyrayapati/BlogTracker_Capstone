using clientWebApp.Models;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin = clientWebApp.Models.Admin;

namespace clientWebApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(ConsoleApp1.Admin admin)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
 
                    var matchingAdmin = db.Admins.FirstOrDefault(e => e.Email_Id == admin.Email_Id);

                    if (matchingAdmin != null)
                    {  
                        if (matchingAdmin.Password == admin.Password)
                        {
                            
                            return RedirectToAction("Index", "Employees",new {Layout= "~/Views/Shared/EmployeeLayout.cshtml" });
                        }
                        else
                        {
                            ModelState.AddModelError("", "Invalid password.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Admin with provided email not found.");
                    }
                }
            }
            return RedirectToAction("AdminFail", "Home");
        }
        public ActionResult AdminFail()
        {
            return View();
        }
        public ActionResult EmployeLogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeLogIn(ConsoleApp1.Employee emp)
        {
            BlogDbContext db = new BlogDbContext();

            var l = db.Employees.Where(e => e.Email_Id == emp.Email_Id);
            if (l != null)
            {
                return RedirectToAction("Index", "BlogInfoes", new { Layout = "~/Views/Shared/AdminLayout.cshtml" });
            }
            else
            {
                return RedirectToAction("EmployeeFail", "Home");
            }
        }
        public ActionResult EmployeeFail()
        {
            return View();
        }

    }
}