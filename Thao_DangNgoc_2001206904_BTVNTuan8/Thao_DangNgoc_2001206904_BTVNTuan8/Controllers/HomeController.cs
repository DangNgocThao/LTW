using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thao_DangNgoc_2001206904_BTVNTuan8.Models;

namespace Thao_DangNgoc_2001206904_BTVNTuan8.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        NhanSuDataContext dl = new NhanSuDataContext();
        public ActionResult DanhMucPhongBan()
        {
            return View(dl.tbl_Deparments.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult XLCreate(tbl_Deparment t)
        {
            dl.tbl_Deparments.InsertOnSubmit(t);
            dl.SubmitChanges();
            return RedirectToAction("DanhMucPhongBan");
        }
        public ActionResult Update(int id)
        {
            tbl_Deparment t = dl.tbl_Deparments.FirstOrDefault(s => s.DeptId == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult Update(int id, tbl_Deparment t)
        {
            tbl_Deparment f = dl.tbl_Deparments.FirstOrDefault(s => s.DeptId == id);
            f.Name = t.Name;
            UpdateModel(f);
            dl.SubmitChanges();
            return RedirectToAction("DanhMucPhongBan");
        }
        public ActionResult Details(int id,string name)
        {
            List<tbl_Employee> ds = dl.tbl_Employees.Where(t => t.DeptId == id).ToList();
            ViewBag.ten = name;
            return View(ds);
        }
    }
}
