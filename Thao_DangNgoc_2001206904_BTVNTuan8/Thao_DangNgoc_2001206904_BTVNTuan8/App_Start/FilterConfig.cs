using System.Web;
using System.Web.Mvc;

namespace Thao_DangNgoc_2001206904_BTVNTuan8
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}