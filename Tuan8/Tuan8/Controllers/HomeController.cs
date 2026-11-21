using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan8.Models;

namespace Tuan8.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        An_1DataContext dl = new An_1DataContext();
        public ActionResult DSTheLoaiTin()
        {
            return View(dl.Theloaitins.ToList());
        }
        public ActionResult ThemMoi()
        {
            return View();
        }
        public ActionResult DSTin()
        {
            return View(dl.Tintucs.ToList());
        }
        public ActionResult XLThem(Theloaitin t)
        {
            dl.Theloaitins.InsertOnSubmit(t);
            dl.SubmitChanges();
            return RedirectToAction("DSTheLoaiTin");
        }
        public ActionResult Edit(int id)
        {
            Theloaitin t = dl.Theloaitins.FirstOrDefault(s => s.IDLoai == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult Edit(int id, Theloaitin t)
        {
            Theloaitin f = dl.Theloaitins.FirstOrDefault(s => s.IDLoai == id);
            f.Tentheloai = t.Tentheloai;
            UpdateModel(f);
            dl.SubmitChanges();
            return RedirectToAction("DSTheLoaiTin");
        }
        public ActionResult Delete(int id)
        {
            Theloaitin t = dl.Theloaitins.FirstOrDefault(s => s.IDLoai == id);
            dl.Theloaitins.DeleteOnSubmit(t);
            dl.SubmitChanges();
            return RedirectToAction("DSTheLoaiTin");
        }
    }
}
