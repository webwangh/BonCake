using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BonCake.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult GoodsInfo()
        {
            return View();
        }
        public ActionResult AllGoods()
        {
            return View();
        }
    }
}