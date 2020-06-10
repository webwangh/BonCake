using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BonCake.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Regist()
        {
            return View();
        }
        public ActionResult UserCenter()
        {
            return View();
        }
        public ActionResult ShoppingCar()
        {
            return View();
        }
    }
}