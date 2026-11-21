using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai1_Tuan1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(int id)
        {
            ViewBag.ten = "Đặng Ngọc Thảo";
            ViewData["lop"] = "11DHTH11";
            ViewData["id"] = id;
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult XuLyDangNhap()
        {
            Session["tendn"] = "DNT";
            return View();
        }
    }
}
