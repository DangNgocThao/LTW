using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tuan10.Models;
namespace Tuan10.Models
{
    public class item
    {
        DataSanPhamDataContext dl = new DataSanPhamDataContext();
        public int ma { get; set; }
        public string ten { get; set; }
        public double gia { get; set; }
        public string hinh { get; set; }
        public string moTa { get; set; }
        public int soluong { get; set; }
        public item(int ma,int sl)
        {
            this.ma = ma;
            tbl_SanPham a = dl.tbl_SanPhams.FirstOrDefault(x => x.MaSanPham == ma);
            this.ten = a.TenSP;
            this.gia = double.Parse(a.DonGia.ToString());
            this.hinh = a.HinhAnh;
            this.moTa = a.MoTa;
            this.soluong = sl;
        }
        public double thanhTien
        {
            get { return gia * soluong; }
        }
    }
    public class GioHang
    {
        public List<item> ds;
        public GioHang()
        {
            ds = new List<item>();
        }
        public void them(int ma, int sl)
        {
            item x = new item(ma, sl);
            ds.Add(x);
        }
        public int demSoLuongMatHang()
        {
            return ds.Count();
        }
        public int demSoLuongSP()
        {
            return ds.Sum(x => x.soluong);
        }
    }
}