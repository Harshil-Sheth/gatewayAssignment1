using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationWithASPNETMVC.Models;

namespace ValidationWithASPNETMVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Account account)
        {
            if(account.Username != null && account.Username.Equals("Harshil"))
            {
                ModelState.AddModelError("Username", "Username already exists");
            }
            if (ModelState.IsValid)
            {
                ViewBag.account = account;
                return View("Success");
            }
            return View("Index");
        }
    }
}