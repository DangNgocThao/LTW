using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai2_Tuan4.Models;

namespace Bai2_Tuan4.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public DuLieu dl = new DuLieu();
        public ActionResult Index()
        {
            ViewBag.dem = dl.getSL();
            return View(dl.dsNV);
        }

    }
}
