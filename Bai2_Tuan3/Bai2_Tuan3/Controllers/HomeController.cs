using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai2_Tuan3.Models;

namespace Bai2_Tuan3.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult DangKy()
        {
            return View();
        }
        public ActionResult XLDangKy(user a, HttpPostedFileBase fileUpload)
        {
            a.hinh = fileUpload.FileName;
            string fullFileName = Server.MapPath("/Images/" + fileUpload.FileName);
            fileUpload.SaveAs(fullFileName);
            return View(a);
        }
    }
}
