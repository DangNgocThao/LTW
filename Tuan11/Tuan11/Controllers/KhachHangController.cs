using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan11.Models;

namespace Tuan11.Controllers
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
        public void LuuGioHang(Giohang gio)
        {
            Session["gh"]=gio;
        }
        public Giohang LayGioHang()
        {
            Giohang gio = (Giohang)Session["gh"];
            return gio;
        }
        public ActionResult ChonMua(int id)
        {
            Giohang g = LayGioHang();
            if (g == null)
            {
                g = new Giohang();
                g.Them(id, 1);
            }
            else
            {
                Item s = g.lstSP.FirstOrDefault(t => t.MaSach == id);
                if (s == null)
                    g.Them(id, 1);
                else
                    s.SoLuongMua++;
            }
            LuuGioHang(g);
            return RedirectToAction("Index");
        }
        public ActionResult XoaGioHang(int id)
        {
            Giohang g = LayGioHang();
            g.Xoa(id);
            return View("XemGioHang");
        }
        public ActionResult XemGioHang()
        {
            Giohang g = LayGioHang();
            List<Item> ds = new List<Item>();
            if (g != null)
                ds = g.lstSP;
            return View(ds);
        }
    }
}
