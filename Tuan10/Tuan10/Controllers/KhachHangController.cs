using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan10.Models;

namespace Tuan10.Controllers
{
    public class KhachHangController : Controller
    {
        //
        // GET: /KhachHang/
        DataDataContext dl = new DataDataContext();
        public ActionResult Index()
        {
            List<Sach> ds = dl.Saches.Take(7).ToList();
            return View(ds);
        }
        public ActionResult DSChuDe()
        {
            List<ChuDe> ds = dl.ChuDes.Take(7).ToList();
            return PartialView(ds);
        }
        public ActionResult DSNXB()
        {
            List<NhaXuatBan> ds = dl.NhaXuatBans.Take(7).ToList();
            return PartialView(ds);
        }
        public ActionResult XemChiTiet(int id)
        {
            Sach s = dl.Saches.FirstOrDefault(t=>t.MaSach==id);
            ViewBag.ThamGia = dl.ThamGias.Where(t => t.MaSach == id).ToList();
            return View(s);
        }
        public ActionResult SachTheoCD(int id)
        {
            List<Sach> ds = dl.Saches.Where(t => t.MaChuDe == id).ToList();
            ds = ds.OrderBy(t => t.GiaBan).ToList();
            return View("Index", ds);
        }
    }
}
