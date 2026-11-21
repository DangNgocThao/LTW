using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DangNgocThao_2001206904_KT2.Models;

namespace DangNgocThao_2001206904_KT2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        DataDataContext dl = new DataDataContext();
        public ActionResult Index()
        {
            return View(dl.Tours.ToList());
        }
        public ActionResult DanhMucTour()
        {
            return PartialView(dl.Danhmucs.ToList());
        }
        public ActionResult dsTheoDM(int id)
        {
            return View("Index", dl.Tours.Where(t => t.MaDM == id).ToList());
        }
        public ActionResult timKiem(FormCollection col)
        {
            return View("Index", dl.Tours.Where(t => t.TenTour.Contains(col["tim"])).ToList());
        }
        public ActionResult dangNhap()
        {
            return View();
        }
        public ActionResult xlDangNhap(FormCollection col)
        {
            KhachHang kh = dl.KhachHangs.FirstOrDefault(t => t.SoDT == col["sdt"] && t.MatKhau == col["mk"]);
            if (kh != null)
            {
                Session["kh"] = kh;
                return RedirectToAction("Index","Home");
            }
            return View("dangNhap");
        }
        public ActionResult chiTiet(int id)
        { 
            Tour t=dl.Tours.FirstOrDefault(a=>a.MaTour==id);
            ViewBag.dv = dl.ChiTietTours.Where(a => a.MaTour == id).ToList();
            return View(t);
        }
        public void luugh(GioHang g)
        {
            Session["gh"] = g;
        }
        public GioHang laygh()
        {
            return (GioHang)Session["gh"];
        }
        public ActionResult chonMua(int id)
        {
            GioHang g = laygh();
            if (g == null)
            {
                g = new GioHang();
                g.them(id, 1);
            }
            else
            {
                Item s = g.lst.FirstOrDefault(t => t.ma == id);
                if (s == null)
                    g.them(id, 1);
                else
                    s.soluong++;
            }
            luugh(g);
            return RedirectToAction("Index");
        }
        public ActionResult XemGioHang()
        {
            GioHang g = laygh();
            List<Item> ds = new List<Item>();
            if (g != null)
                ds = g.lst;
            return View(ds);
        }
        public ActionResult DatHang(FormCollection c)
        {
            GioHang g = laygh();
            KhachHang kh = (KhachHang)Session["kh"];
            DatHang DDH = new DatHang();
            DDH.MaKH = kh.MaKH;
            DDH.NgayDat = DateTime.Now;
            string tinhTrang = c["tt"];
            if (tinhTrang != null)
                DDH.TinhTrang = int.Parse(tinhTrang);

            int ma = 0;
            List<DatHang> ds = dl.DatHangs.ToList();
            if (ds.Count != 0)
                ma = ds.Count + 1;
            DDH.MaDH = ma;
            dl.DatHangs.InsertOnSubmit(DDH);
            dl.SubmitChanges();

            foreach(Item x in g.lst)
            {
                ChiTietDatHang ctdh = new ChiTietDatHang();
                ctdh.MaDH = ma;
                ctdh.MaTour = x.ma;
                ctdh.SoLuong = x.soluong;
                dl.ChiTietDatHangs.InsertOnSubmit(ctdh);
            }
            dl.SubmitChanges();

            g.lst.Clear();
            luugh(g);
            return RedirectToAction("Index");
        }
        public ActionResult ThemHang()
        {
            List<Danhmuc> ds = dl.Danhmucs.ToList();
            return View(ds);
        }
        [HttpPost]
        public ActionResult ThemHang(Tour a, HttpPostedFileBase file1, HttpPostedFileBase file2)
        {
            if (file1 != null)
            {
                string fileName = Server.MapPath("/Hinhanh/" + file1.FileName);
                file1.SaveAs(fileName);
                a.hinh = file1.FileName;
            }

            if (file2 != null)
            {
                string fileName2 = Server.MapPath("/Hinhanh/" + file2.FileName);
                file2.SaveAs(fileName2);
                a.dsHinh = file2.FileName;
            }
            dl.Tours.InsertOnSubmit(a);
            dl.SubmitChanges();
            return RedirectToAction("Index");
        }
        public ActionResult lichSuGiaoDich(int id)
        {
            List<DatHang> ds = dl.DatHangs.Where(x => x.MaKH == id).ToList();
            ViewBag.error = "";
            if (ds == null || ds.Count == 0)
                ViewBag.error = "Loi";
            List<ChiTietDatHang> dsCT = dl.ChiTietDatHangs.ToList();
            ViewBag.dsCT = dsCT;
            return View(ds);
        }
    }
}
