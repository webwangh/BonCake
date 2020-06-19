using BonCake.Models;
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
        public ActionResult LoginUser(LoginUser user)
        {
            using (BonCakeEntities db = new BonCakeEntities())
            {
                var loginUser = db.LoginUser.Where(u => u.loginName.Equals(user.loginName) && u.loginPwd.Equals(user.loginPwd)).SingleOrDefault();
                if (loginUser == null)
                {
                    //提示：用户名或密码错误
                    TempData["msg"] = "用户名或密码错误";
                    //跳回登录方法 
                    return RedirectToAction("Login");
                }
                //登录成功 跳回首页方法 把用户名放入Session
                //Session["UserName"] = loginUser.userName;
                //Session["HeadPic"] = loginUser.userPhone;
                Session["user"] = loginUser;
                return RedirectToAction("../Index/Index");
            }
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