using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteVatlieuXayDung.Models;
namespace WebsiteVatlieuXayDung.Models
{
    public class Item
    {
        DataDataContext dl = new DataDataContext();
        public string maHH { get; set; }
        public string tenHH { get; set; }
        public string moTa { get; set; }
        public string hinhSanPham { get; set; }
        public int soluong { get; set; }
        public double gia { get; set; }
        public string diaChi { get; set; }
        public string xuatXu { get; set; }
        public Item(string ma)
        {
            this.maHH = ma;
            HANGHOA a = dl.HANGHOAs.FirstOrDefault(x => x.MAHH == ma);
            this.tenHH = a.TENHH;
            this.gia = double.Parse(a.GIA.ToString());
            this.hinhSanPham = a.HINHSANPHAM;
            this.moTa = a.MOTA;
            this.soluong = 1;
        }
        public Item(string ma, int sl)
        {
            this.maHH = ma;
            HANGHOA a = dl.HANGHOAs.FirstOrDefault(x => x.MAHH == ma);
            this.tenHH = a.TENHH;
            this.gia = double.Parse(a.GIA.ToString());
            this.hinhSanPham = a.HINHSANPHAM;
            this.moTa = a.MOTA;
            this.soluong = sl;
        }
        public double thanhTien
        {
            get { return gia * soluong; }
        }
    }
}