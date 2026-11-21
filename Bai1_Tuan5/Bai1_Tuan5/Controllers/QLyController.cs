using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai1_Tuan5.Models;

namespace Bai1_Tuan5.Controllers
{
    public class QLyController : Controller
    {
        //
        // GET: /QLy/
        DuLieu dl = new DuLieu();
        public ActionResult HienThiTheLoai()
        {
            return View(dl.listTheLoai);
        }
        public ActionResult HienThiSanPham()
        {
            return View(dl.listSanPham);
        }
        public ActionResult DMTheLoai()
        {
            return PartialView(dl.listTheLoai);
        }
        public ActionResult SanPhamTheoLoai(string id)
        {
            List<SanPham> dssp = dl.listSanPham.Where(t => t.maloai == id).ToList();
            return View(dssp);
        }
        public ActionResult ThemTheLoai()
        {
            return View();
        }
        public ActionResult XLThem(Category a)
        {
            dl.listTheLoai.Add(a);
            return View(dl.listTheLoai);
        }
    }
}
