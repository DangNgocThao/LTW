using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using WebsiteVatlieuXayDung.Models;

namespace WebsiteVatlieuXayDung.Controllers
{
    public class HomeController : Controller
    {
        DataDataContext dl = new DataDataContext();
        // GET: Home

        public ActionResult QuanLyDonHang()
        {
            List<HOADONKH> ds = dl.HOADONKHs.ToList();
            ViewBag.dsCTHD = dl.CHITIETHOADONKHs.ToList();
            return View(ds);
        }
        public ActionResult QuanLyGiaoHang()
        {
            List<GIAOHANG> ds = dl.GIAOHANGs.ToList();
            return View(ds);
        }
        public ActionResult LuuTinhTrang(FormCollection c)
        {
            foreach (var item in dl.GIAOHANGs.ToList())
            {
                if (c[item.MAHD] != null)
                {
                    item.TINHTRANG = c[item.MAHD];
                    UpdateModel(item);
                }
            }
            dl.SubmitChanges();
            return RedirectToAction("QuanLyGiaoHang");
        }
        public ActionResult LichSuMuaHang()
        {

            NGUOIDUNG kh = (NGUOIDUNG)Session["kh"];
            if (kh == null)
                return View("BatBuocDangNhap");
            List<HOADONKH> dsHD = dl.HOADONKHs.Where(x => x.SDT == kh.SDT).ToList();
            ViewBag.dsGH = dl.GIAOHANGs.ToList();
            ViewBag.dsCTHD = dl.CHITIETHOADONKHs.ToList();
            return View(dsHD);
        }
        public ActionResult XuLyDH(FormCollection col)
        {
            NGUOIDUNG kh = (NGUOIDUNG)Session["kh"];
            GioHang g = LayGioHang();

            HOADONKH hd = new HOADONKH();
            hd.MAHD = "HD-" + (dl.HOADONKHs.Count() + 1).ToString();
            hd.SDT = kh.SDT;
            hd.NGAY = DateTime.Now;
            hd.TONGTIEN = g.tongTien();
            hd.TONGSOLUONGSPDAMUA = g.soLuongSP();
            dl.HOADONKHs.InsertOnSubmit(hd);
            dl.SubmitChanges();

            GIAOHANG gh = new GIAOHANG();
            gh.MAHD = hd.MAHD;
            gh.DIACHIGIAOHANG = col["DIACHIGIAOHANG"].ToString();
            gh.TINHTRANG = "Chưa giao";
            dl.GIAOHANGs.InsertOnSubmit(gh);
            dl.SubmitChanges();

            foreach (var item in g.ds)
            {
                CHITIETHOADONKH ct = new CHITIETHOADONKH();
                ct.MAHD = hd.MAHD;
                ct.MAHH = item.maHH;
                ct.SOLUONG = item.soluong;
                dl.CHITIETHOADONKHs.InsertOnSubmit(ct);
            }
            dl.SubmitChanges();

            g.ds.Clear();
            LuuGioHang(g);

            return RedirectToAction("DSHang");
        }
        public ActionResult XacNhanHang()
        {
            return View(Session["kh"]);
        }
        public ActionResult TimKiem(FormCollection f)
        {
            string s = f["search"];
            List<HANGHOA> ds = dl.HANGHOAs.Where(t => t.TENHH.Contains(s) || t.MOTA.Contains(s)).ToList();
            return View("DSHang", ds);
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(NGUOIDUNG kh, FormCollection f)
        {
            if (f["HO"] == string.Empty || f["TENKH"] == string.Empty || f["SDT"] == string.Empty)
            {
                ViewBag.error = "Không được bỏ trống một thông tin nào!";
                return View("DangKy");
            }
            else if (f["MATKHAU"] != f["confirm_pwd"])
            {
                ViewBag.error = "Mật khẩu không trùng khớp!";
                return View("DangKy");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        string ten = f["HO"].Trim() + " " + f["TENKH"].Trim();
                        kh.TENKH = ten;
                        kh.QUANLY = false;
                        dl.NGUOIDUNGs.InsertOnSubmit(kh);
                        dl.SubmitChanges();
                    }
                    catch
                    {
                        ViewBag.error = "Số điện thoại đã được đăng ký!";
                        return View("DangKy");
                    }

                }
                return RedirectToAction("DangNhap");
            }
        }
        public ActionResult DanhMucLoai()
        {
            List<LOAIHANG> dsLoai = dl.LOAIHANGs.ToList();
            return PartialView(dsLoai);
        }
        public ActionResult SPTheoLoai(string id)
        {
            List<HANGHOA> ds = dl.HANGHOAs.Where(t => t.MALH == id).ToList();
            return View("DSHang", ds);
        }
        public ActionResult DSLoai()
        {
            return View(dl.LOAIHANGs);
        }
        public ActionResult DSHang()
        {
            return View(dl.HANGHOAs);
        }
        public ActionResult DSHangTheoLoai(string id)
        {
            ViewBag.ten = dl.LOAIHANGs.FirstOrDefault(x => x.MALH.Equals(id)).TENLH;
            List<HANGHOA> a = dl.HANGHOAs.Where(x => x.MALH.Equals(id)).ToList();
            return View("DSHang", a);
        }
        public ActionResult ThemSanPham()
        {
            ViewBag.MALH = new SelectList(dl.LOAIHANGs.ToList().OrderBy(t => t.TENLH), "MALH", "TENLH");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemSanPham(HANGHOA hang, HttpPostedFileBase fileupload)
        {
            ViewBag.MALH = new SelectList(dl.LOAIHANGs.ToList().OrderBy(t => t.TENLH), "MALH", "TENLH");

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
                    var path = Path.Combine(Server.MapPath("~/Images"), filename);
                    if (System.IO.File.Exists(path))
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    else
                        fileupload.SaveAs(path);
                    hang.HINHSANPHAM = filename;
                    dl.HANGHOAs.InsertOnSubmit(hang);
                    dl.SubmitChanges();
                }
                return RedirectToAction("DSHang");
            }
        }
        public ActionResult SuaSanPham(string id)
        {
            ViewBag.MALH = new SelectList(dl.LOAIHANGs.ToList().OrderBy(t => t.TENLH), "MALH", "TENLH");
            HANGHOA f = dl.HANGHOAs.FirstOrDefault(s => s.MAHH == id);
            return View(f);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaSanPham(string id, HANGHOA hang, HttpPostedFileBase fileupload)
        {
            ViewBag.MALH = new SelectList(dl.LOAIHANGs.ToList().OrderBy(t => t.TENLH), "MALH", "TENLH");

            HANGHOA f = dl.HANGHOAs.FirstOrDefault(s => s.MAHH == id);
            f.MALH = hang.MALH;
            f.TENHH = hang.TENHH;
            f.MOTA = hang.MOTA;
            f.SOLUONG = hang.SOLUONG;
            f.GIA = hang.GIA;
            f.DIACHI = hang.DIACHI;
            f.XUATXU = hang.XUATXU;

            if (fileupload != null)
            {
                if (ModelState.IsValid)
                {
                    var filename = Path.GetFileName(fileupload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), filename);
                    if (System.IO.File.Exists(path))
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    else
                        fileupload.SaveAs(path);
                    hang.HINHSANPHAM = filename;
                }
                f.HINHSANPHAM = hang.HINHSANPHAM;
            }
            UpdateModel(f);
            dl.SubmitChanges();
            return RedirectToAction("DSHang");
        }
        public ActionResult ChiTietSanPham(string id)
        {
            HANGHOA a = dl.HANGHOAs.FirstOrDefault(x => x.MAHH.Equals(id));
            return View(a);
        }
        public ActionResult XoaSanPham(string id)
        {
            HANGHOA a = dl.HANGHOAs.FirstOrDefault(x => x.MAHH.Equals(id));
            return View(a);
        }
        [HttpPost]
        public ActionResult XuLyXoaSanPham(string id)
        {
            HANGHOA a = dl.HANGHOAs.FirstOrDefault(x => x.MAHH.Equals(id));
            dl.HANGHOAs.DeleteOnSubmit(a);
            dl.SubmitChanges();
            return RedirectToAction("DSHang");
        }
        public void LuuGioHang(GioHang g)
        {
            Session["gh"] = g;
        }
        public GioHang LayGioHang()
        {
            return (GioHang)Session["gh"];
        }
        public ActionResult ThemMatHang(string id)
        {
            GioHang g = LayGioHang();
            if (g == null)
            {
                g = new GioHang();
                g.them(id, 1);
            }
            else
            {
                Item a = g.ds.FirstOrDefault(x => x.maHH == id);
                if (a == null)
                {
                    g.them(id, 1);
                }
                else
                {
                    a.soluong += 1;
                }
            }
            LuuGioHang(g);
            return RedirectToAction("DSHang");
        }
        public ActionResult XoaSanPhamTrongGiohang(string id)
        {
            GioHang gh = LayGioHang();
            Item a = gh.ds.FirstOrDefault(x => x.maHH == id);
            gh.ds.Remove(a);
            LuuGioHang(gh);
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaGioHang(string id)
        {
            GioHang g = LayGioHang();
            Item a = g.ds.FirstOrDefault(x => x.maHH == id);
            if (a.soluong == 1)
                g.ds.Remove(a);
            else
                a.soluong -= 1;
            return RedirectToAction("GioHang");
        }
        public ActionResult CapNhatSoLuong(string id, FormCollection col)
        {
            GioHang gh = LayGioHang();
            Item sp = gh.ds.FirstOrDefault(x => x.maHH == id);
            if (sp != null)
            {
                sp.soluong = int.Parse(col["txtSoluong"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult LuuSoLuongSP(FormCollection c)
        {
            string ma = c["btn"];
            int soLuong = int.Parse(c["soLuong_" + ma]);
            GioHang gh = LayGioHang();
            Item a = gh.ds.FirstOrDefault(x => x.maHH == ma);
            if (soLuong == 0)
                gh.ds.Remove(a);
            else
                a.soluong = soLuong;
            return RedirectToAction("GioHang");
        }
        public ActionResult GioHang()
        {
            List<Item> ds = new List<Item>();
            GioHang g = LayGioHang();
            if (g != null)
                ds = g.ds.ToList();
            return View(ds);
        }

        public ActionResult DangNhap()
        {
            if (Session["kh"] != null)
            {
                Session["kh"] = null;
                return RedirectToAction("DSHang");
            }
            return View();
        }
        public ActionResult XuLyDangNhap(FormCollection c)
        {
            NGUOIDUNG kh = dl.NGUOIDUNGs.FirstOrDefault(t => t.SDT == c["txtSDT"] && t.MATKHAU == c["txtPass"]);
            if (kh == null)
            {
                ViewBag.kq = "Tài khoản hoặc mật khẩu không đúng!";
                return View("DangNhap");
            }
            Session["kh"] = kh;
            return RedirectToAction("DSHang");
        }
        public ActionResult BatBuocDangNhap()
        {
            return View();
        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("DSHang", "Home");
        }
        public ActionResult ThemLoai()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemLoai(LOAIHANG loai)
        {
            try
            {
                dl.LOAIHANGs.InsertOnSubmit(loai);
                dl.SubmitChanges();
                return RedirectToAction("DSLoai");
            }
            catch
            {
                ViewBag.loi = "Mã loại đã tồn tại";
                return View("ThemLoai");
            }
        }
        public ActionResult SuaLoai(string id)
        {
            LOAIHANG f = dl.LOAIHANGs.FirstOrDefault(s => s.MALH == id);
            return View(f);
        }
        [HttpPost]
        public ActionResult SuaLoai(string id, LOAIHANG loai)
        {
            LOAIHANG f = dl.LOAIHANGs.FirstOrDefault(s => s.MALH == id);
            f.MALH = loai.MALH;
            f.TENLH = loai.TENLH;
            UpdateModel(f);
            dl.SubmitChanges();
            return RedirectToAction("DSLoai");
        }
        public ActionResult XoaLoai(string id)
        {
            LOAIHANG f = dl.LOAIHANGs.FirstOrDefault(s => s.MALH == id);
            return View(f);
        }
        [HttpPost]
        public ActionResult XuLyXoaLoai(string id)
        {
            LOAIHANG f = dl.LOAIHANGs.FirstOrDefault(s => s.MALH == id);
            dl.LOAIHANGs.DeleteOnSubmit(f);
            dl.SubmitChanges();
            return RedirectToAction("DSLoai");
        }
    }
}