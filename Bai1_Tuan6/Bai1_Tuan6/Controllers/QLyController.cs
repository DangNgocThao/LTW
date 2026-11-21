using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai1_Tuan6.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Bai1_Tuan6.Controllers
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
        public ActionResult XLThem(Category c)
        {
            string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            string str_insert = "Insert into Loai(TenLoai) values ('" + c.tenloai + "')";
            SqlCommand cmd = new SqlCommand(str_insert, con);

            int kq = cmd.ExecuteNonQuery();
            if (kq == 1)
                ViewBag.tt = "Đã thêm thành công";
            else
                ViewBag.tt = "Thêm thất bại";

            con.Close();
            return View();
        }
        public ActionResult ThemSanPham()
        {
            ViewBag.loai = dl.listTheLoai;
            return View();
        }
        public ActionResult XLThemSP(SanPham c, HttpPostedFileBase fUpload)
        {
            string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            string tenfile = fUpload.FileName;

            string str_insert = "Insert into SanPham(TenSP, DuongDan, Gia, Mota, MaLoai) values ('" + c.tensp + "','" + tenfile + "','" + c.gia + "', N'" + c.mota + "', '" + c.maloai + "')";
            SqlCommand cmd = new SqlCommand(str_insert, con);

            int kq = cmd.ExecuteNonQuery();
            if (kq == 1)
            {
                fUpload.SaveAs(Server.MapPath("/HinhAnh/" + tenfile));
                return RedirectToAction("HienThiSanPham");
            }
            else
            {
                ViewBag.tt = "Thêm thất bại";
                return RedirectToAction("ThemSanPham");
            }

            con.Close();
            //return View();
        }
    }
}
