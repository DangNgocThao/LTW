using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan10.Models;
namespace Tuan10.Controllers
{
    public class HomeController : Controller
    {
        DataSanPhamDataContext dl = new DataSanPhamDataContext();
        //
        // GET: /Home/
        public ActionResult ListSanPham()
        {
            List<tbl_SanPham> ds = dl.tbl_SanPhams.ToList();
            return View(ds);
        }
        public void LuuGioHang(GioHang g)
        {
            Session["gh"] = g;
        }
        public GioHang LayGioHang()
        {
            return (GioHang)Session["gh"];
        }
        public ActionResult ThemMatHang(int id)
        {
            GioHang g = LayGioHang();
            if (g == null)
            {
                g = new GioHang();
                g.them(id, 1);
            }
            else
            {
                item a=g.ds.FirstOrDefault(x=>x.ma==id);
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
            return RedirectToAction("ListSanPham");
        }
        public ActionResult GioHang()
        {
            List<item> ds = new List<item>();
            GioHang g = LayGioHang();
            if (g != null)
                ds = g.ds.ToList();
            return View(ds);
        }
        public ActionResult XoaGioHang(int id)
        {
            GioHang g=LayGioHang();
            item a = g.ds.FirstOrDefault(x => x.ma == id);
            if (a.soluong == 1)
                g.ds.Remove(a);
            else
                a.soluong-=1;
            return RedirectToAction("GioHang");
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        public ActionResult XLDangNhap(FormCollection col)
        {
            tbl_KhachHang kh = dl.tbl_KhachHangs.FirstOrDefault(t => t.TenKH == col["txtName"] && t.MatKhau == col["txtPass"]);
            if (kh != null)
            {
                Session["kh"] = kh;
                return RedirectToAction("ListSanPham", "Home");
            }
            return View("DangNhap");
        }
        public ActionResult DangXuat()
        {
            Session["kh"] = null;
            return RedirectToAction("ListSanPham", "Home");
        }
    }
}
