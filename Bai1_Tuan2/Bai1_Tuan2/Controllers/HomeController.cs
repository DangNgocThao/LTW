using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai1_Tuan2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            List<string> ds = new List<string>();
            ds.Add("Trương Mạnh Hùng");
            ds.Add("Nguyễn Hải Yến");
            ds.Add("Trương Thị Khánh Uyên");
            ds.Add("Trương Nguyễn Quỳnh Anh");

            ViewBag.key = ds;
            return View();
        }
        public ActionResult Index2()
        {
            List<string> l = new List<string>();
            l.Add("Cam");
            l.Add("Xoài");
            l.Add("Cóc");
            l.Add("Ổi");

            ViewBag.tc = l;
            return View();
        }
    }
}
