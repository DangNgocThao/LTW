using System.Web;
using System.Web.Mvc;

namespace DangNgocThao_2001206904_KT2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}