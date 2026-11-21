using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan13.Models;

namespace Tuan13.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        DataDataContext data = new DataDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult QLDH()
        {
            return View(data.tbl_HoaDons.ToList());
        }
        public ActionResult ThongKeHoaDon(int id)
        {
            return View(data.tbl_ChiTiets.Where(i => i.MaHD == id).ToList());
        }
        public ActionResult QlDhChuaGiao()
        {
            return View("QLDH", data.tbl_HoaDons.Where(i => i.NgayThanhToan == null).ToList());
        }
    }
}
