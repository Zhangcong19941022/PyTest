using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeiyingMes.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult IsAdmin()
        {
            return View();
        }


        public ActionResult testpage()
        {
            return View();
        }
    }
}