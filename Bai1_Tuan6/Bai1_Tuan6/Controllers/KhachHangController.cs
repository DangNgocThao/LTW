using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai1_Tuan6.Models;

namespace Bai1_Tuan6.Controllers
{
    public class KhachHangController : Controller
    {
        //
        // GET: /KhachHang/

        DuLieu dl = new DuLieu();

        public ActionResult Index()
        {
            return View(dl.listSanPham);
        }

    }
}
