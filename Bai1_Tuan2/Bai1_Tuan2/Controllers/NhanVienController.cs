using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai1_Tuan2.Models;

namespace Bai1_Tuan2.Controllers
{
    public class NhanVienController : Controller
    {
        //
        // GET: /NhanVien/

        public ActionResult Index()
        {
            Employee nv = new Employee();
            return View(nv);
        }
        public ActionResult Index2()
        {
            Employee nv = new Employee();
            return View(nv);
        }
    }
}
