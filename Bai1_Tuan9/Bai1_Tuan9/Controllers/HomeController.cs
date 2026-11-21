using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.IO;
using Bai1_Tuan9.Models;

namespace Bai1_Tuan9.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        QLBanSachDataContext dl = new QLBanSachDataContext();
        public ActionResult DMSach()
        {
            return View(dl.Saches.ToList());
        }
        public ActionResult ThemSachMoi()
        {
            ViewBag.MaChuDe = new SelectList(dl.ChuDes.ToList().OrderBy(t => t.TenChuDe), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(dl.NhaXuatBans.ToList().OrderBy(t => t.TenNXB), "MaNXB", "TenNXB");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemSachMoi(Sach sach,HttpPostedFileBase fileupload)
        {
            ViewBag.MaChuDe = new SelectList(dl.ChuDes.ToList().OrderBy(t => t.TenChuDe), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(dl.NhaXuatBans.ToList().OrderBy(t => t.TenNXB), "MaNXB", "TenNXB");

            if (fileupload==null)
            {
                ViewBag.ThongBao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var filename = Path.GetFileName(fileupload.FileName);
                    var path = Path.Combine(Server.MapPath("~/HinhAnhSP"), filename);
                    if (System.IO.File.Exists(path))
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    else
                        fileupload.SaveAs(path);
                    sach.AnhBia = filename;
                    dl.Saches.InsertOnSubmit(sach);
                    dl.SubmitChanges();
                }
                return RedirectToAction("DMSach");
            }            
        }
    }
}
