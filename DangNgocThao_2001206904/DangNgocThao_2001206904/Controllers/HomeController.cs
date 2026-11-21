using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DangNgocThao_2001206904.Models;

namespace DangNgocThao_2001206904.Controllers
{
    public class HomeController : Controller
    {
        DataDataContext dl = new DataDataContext();
        public ActionResult Index()
        {
            return View(dl.NongSans.ToList());
        }

        public ActionResult dsDanhMuc()
        {
            return PartialView(dl.DanhMucs.Take(3).ToList());
        }

        public ActionResult dsTheoDM(int id)
        {
            return View("Index", dl.NongSans.Where(t => t.Loai.MaDanhMuc == id).ToList());
        }

        public ActionResult DangNhap()
        {
            return View();
        }
        public ActionResult XLDangNhap(FormCollection col)
        {
            KhachHang kh = dl.KhachHangs.FirstOrDefault(t => t.DienThoai == col["txtName"] && t.MatKhau == col["txtPass"]);
            if (kh != null)
            {
                Session["kh"] = kh;
                return RedirectToAction("Index", "Home");
            }
            return View("DangNhap");
        }
        public ActionResult DangXuat()
        {
            Session["kh"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult TimKiem()
        {
            return View(dl.Loais.ToList());
        }
        [HttpPost]
        public ActionResult TimKiem(FormCollection col)
        {
            int ma = int.Parse(col["txtma"].ToString());
            string ten = col["txtten"].ToString().Trim();
            List<NongSan> ns;
            if (ten != string.Empty && col["mota"] != null)
                ns = dl.NongSans.Where(t => t.MaLoaiSP == ma && (t.TenSP.Contains(ten) || t.MoTa.Contains(ten))).ToList();
            else if (ten != string.Empty)
                ns = dl.NongSans.Where(t => t.MaLoaiSP == ma && t.TenSP.Contains(ten)).ToList();
            else
                ns = dl.NongSans.Where(t => t.MaLoaiSP == ma).ToList();
            return View("Index", ns);
        }
        public ActionResult ChiTietSanPham(string id)
        {
            NongSan ns = dl.NongSans.FirstOrDefault(t => t.idSP == id);
            ViewBag.tinh = dl.GiaoHangs.Where(t => t.MaSP == id).ToList();
            ViewBag.splq = dl.NongSans.Where(t => t.MaLoaiSP == ns.MaLoaiSP && t.idSP != id).Take(4).ToList();
            return View(ns);
        }
        public void LuuGioHang(GioHang gio)
        {
            Session["gh"] = gio;
        }
        public GioHang LayGioHang()
        {
            GioHang gio = (GioHang)Session["gh"];
            return gio;
        }
        public ActionResult ChonMua(string id)
        {
            GioHang g = LayGioHang();
            if (g == null)
            {
                g = new GioHang();
                g.Them(id, 1);
            }
            else
            {
                Item s = g.lstSP.FirstOrDefault(t => t.IdSP == id);
                if (s == null)
                    g.Them(id, 1);
                else
                    s.SoLuongMua++;
            }
            LuuGioHang(g);
            return RedirectToAction("Index");
        }
        public ActionResult XoaGioHang(string id)
        {
            GioHang g = LayGioHang();
            g.Xoa(id);
            LuuGioHang(g);
            return RedirectToAction("XemGioHang");
        }
        public ActionResult updateSL(string id, FormCollection col)
        {
            GioHang g = LayGioHang();
            Item sp = g.lstSP.FirstOrDefault(t => t.IdSP == id);
            if (sp != null)
            {
                sp.SoLuongMua = int.Parse(col["txtSoLg"].ToString());
            }
            return RedirectToAction("XemGioHang");
        }
        public ActionResult XemGioHang()
        {
            GioHang g = LayGioHang();
            List<Item> ds = new List<Item>();
            if (g != null)
                ds = g.lstSP;
            return View(ds);
        }
        public ActionResult XacNhanDH()
        {
            return View(Session["kh"]);
        }
        public ActionResult XuLyDH(FormCollection col)
        {
            DonDatHang ddh = new DonDatHang();
            KhachHang kh = (KhachHang)Session["kh"];
            ddh.idDDH = dl.DonDatHangs.Count() + 1;
            ddh.idKhachHang = kh.idKH;
            ddh.NgayDatHang = DateTime.Now;
            ddh.HinhThucGiaoHang = col["cboHinhThucGH"].ToString();
            ddh.GhiChu = col["ghichu"].ToString();
            dl.DonDatHangs.InsertOnSubmit(ddh);
            dl.SubmitChanges();

            Session["gh"] = null;
            return RedirectToAction("Index");
        }
        public ActionResult ThemSP()
        {
            ViewBag.MaLoai = new SelectList(dl.Loais.ToList().OrderBy(t => t.TenLoai), "MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemSP(NongSan ns, HttpPostedFileBase fileupload)
        {
            ViewBag.MaLoai = new SelectList(dl.Loais.ToList().OrderBy(t => t.TenLoai), "MaLoai", "TenLoai");

            if (fileupload == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var filename = Path.GetFileName(fileupload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Hinhanh"), filename);
                    if (System.IO.File.Exists(path))
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    else
                        fileupload.SaveAs(path);
                    ns.HinhDaiDien = filename;
                    dl.NongSans.InsertOnSubmit(ns);
                    dl.SubmitChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}