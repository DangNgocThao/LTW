using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai2_Tuan2.Models;

namespace Bai2_Tuan2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

       static List<Sach> ds = new List<Sach>();
       public ActionResult Index()
        {
            ds.Add(new Sach("S1", "Lẽ Nào Em Không Biết", 64200, "/Image/h1.PNG", "", ""));
            ds.Add(new Sach("S2", "Em là nhà", 58800, "/Image/h2.PNG", "Lan Rùa", "Xoay quanh những đổ vỡ tình cảm, những thách thức, những sự lừa dối mà cô gái trẻ Như Nguyệt phải chịu đựng, chuyện tình yêu trong Em là nhà sẽ đưa bạn qua những cung bậc cảm xúc từ ngọt ngào đến cao trào uất hận, từ bình yên êm ấm đến những nỗi đau chỉ có thể âm thầm chịu đựng."));
            ds.Add(new Sach("S3", "Khu vườn ngôn từ", 71250, "/Image/h3.PNG", "", ""));
            ds.Add(new Sach("S4", "Người truyền ký ức", 49640, "/Image/h4.PNG", "", ""));
            ds.Add(new Sach("S5", "Đạo tình", 77000, "/Image/h5.PNG", "", ""));
            ds.Add(new Sach("S6", "Yêu", 52200, "/Image/h6.PNG", "", ""));
            ds.Add(new Sach("S7", "Kỳ án ánh trăng", 115500, "/Image/h7.PNG", "", ""));
            ds.Add(new Sach("S8", "Cuộc sống không giới hạn", 74000, "/Image/h8.PNG", "", ""));
            return View(ds);
        }
        public ActionResult chitiet(string id)
        {
            Sach s = ds.FirstOrDefault(t => t.Ma == id);
            return View(s);
        }
    }
}
