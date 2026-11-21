using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai1_Tuan2.Models;

namespace Bai1_Tuan2.Controllers
{
    public class PhongBanController : Controller
    {
        //
        // GET: /PhongBan/

        public ActionResult Index()
        {
            List<PhongBan> ds = new List<PhongBan>();
            ds.Add(new PhongBan("P1", "Phòng giám đốc"));
            ds.Add(new PhongBan("P2", "Phòng kế hoạch"));
            ds.Add(new PhongBan("P3", "Phòng kế toán"));
            ds.Add(new PhongBan("P4", "Phòng sản xuất"));
            ds.Add(new PhongBan("P5", "Phòng kinh doanh"));
            return View(ds);
        }

    }
}
