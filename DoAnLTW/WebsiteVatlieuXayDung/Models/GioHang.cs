using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteVatlieuXayDung.Models;
namespace WebsiteVatlieuXayDung.Models
{
    public class GioHang
    {
        public List<Item> ds;
        public GioHang()
        {
            ds = new List<Item>();
        }
        public void them(string ma, int sl)
        {
            Item x = new Item(ma, sl);
            ds.Add(x);
        }
        public int demSoLuongMatHang()
        {
            return ds.Count();
        }
        public int soLuongSP()
        {
            return ds.Sum(x => x.soluong);
        }
        public double tongTien()
        {
            return ds.Sum(x => x.soluong * x.gia);
        }
    }
}