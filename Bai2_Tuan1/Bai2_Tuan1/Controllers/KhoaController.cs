using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Bai2_Tuan1.Models;

namespace Bai2_Tuan1.Controllers
{
    public class KhoaController : Controller
    {
        //
        // GET: /Khoa/

        public ActionResult Index()
        {
            Models.KhoaModels khoaCNTT = new Models.KhoaModels();
            khoaCNTT.Message="FIT-HUFI: HỌC TẬP - NĂNG ĐỘNG - SÁNG TẠO";
            return View(khoaCNTT);
        }

    }
}
