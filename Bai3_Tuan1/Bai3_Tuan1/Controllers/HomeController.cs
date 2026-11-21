using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai3_Tuan1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult SanPham()
        {
            return View();
        }

        public ActionResult DangKy()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult DangNhap()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}