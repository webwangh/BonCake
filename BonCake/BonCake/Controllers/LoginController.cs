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
        public ActionResult LoginUser(User user)
        {
            using (BonCakeEntities2 db = new BonCakeEntities2())
            {
                var loginUser = db.User.Where(u => u.userName.Equals(user.userName) && u.userPwd.Equals(user.userPwd)).SingleOrDefault();
                if (loginUser == null)
                {
                    //提示：用户名或密码错误
                    loginUser = db.User.Where(u => u.userPhone.Equals(user.userName) && u.userPwd.Equals(user.userPwd)).SingleOrDefault();
                    if (loginUser == null)
                    {
                        TempData["Msg"] = "用户名或密码错误";
                        //跳回登录方法 
                        return RedirectToAction("Login");
                    }
                    
                }
                //登录成功 跳回首页方法 把用户放入Session
                Session["user"] = loginUser;
                return RedirectToAction("UserCenter");
            }
        }
        public ActionResult Regist()
        {
            
            return View();
        }
        public ActionResult RegistUser(User user)
        {
            using (BonCakeEntities2 db = new BonCakeEntities2())
            {
                user.userData = DateTime.Now;
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
        }
        //CheckPhone
        public JsonResult CheckPhone(string userPhone)
        {
            using (BonCakeEntities2 db = new BonCakeEntities2())
            {
                var userList = db.User.Where(u => u.userPhone.Equals(userPhone)).ToList();
                //userList.Count > 0 说明用户名存在
                //userList.Count <= 0 说明用户名不存在
                Dictionary<string, object> map = new Dictionary<string, object>();
                map.Add("valid", userList.Count <= 0);
                return Json(map);
            }

        }
        public ActionResult UserCenter()
        {
            return View();
        }
        public ActionResult ModifyUser(User user)
        {
            var userId = (Session["user"] as User).userId;
            using (BonCakeEntities2 db = new BonCakeEntities2())
            {
                var modifyUser = db.User.Where(u => u.userId.Equals(userId)).SingleOrDefault();
                modifyUser.userName = user.userName;
                modifyUser.userSex = user.userSex;
                modifyUser.userPhone = user.userPhone;
                modifyUser.userData = user.userData;
                db.SaveChanges();
            }
            return RedirectToAction("UserCenter");
        }
        public ActionResult ShoppingCar()
        {
            return View();
        }
    }
}