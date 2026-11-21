using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Thao_DangNgoc_2001206904_KT1.Models;

namespace Thao_DangNgoc_2001206904_KT1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        DuLieu dl = new DuLieu();

        public ActionResult Index()
        {
            return View(dl.listsp);
        }
        public ActionResult ChiTiet(string id)
        {
            List<sanpham> dssp = dl.listsp.Where(t => t.masp == id).ToList();
            return View(dssp);
        }
    }
}
