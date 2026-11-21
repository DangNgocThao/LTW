using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tuan11.Models
{
    public class Item
    {
        DataDataContext dl = new DataDataContext();
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string Hinh { get; set; }
        public double DonGia { get; set; }
        public int SoLuongMua { get; set; }

        public Item(int ms)
        {
            MaSach = ms;
            Sach s = dl.Saches.FirstOrDefault(t => t.MaSach == ms);
            TenSach = s.TenSach;
            DonGia = (double)s.GiaBan;
            Hinh = s.AnhBia;

            SoLuongMua = 1;
        }
        public Item(int ms,int sl)
        {
            MaSach = ms;
            Sach s = dl.Saches.FirstOrDefault(t => t.MaSach == ms);
            TenSach = s.TenSach;
            DonGia = (double)s.GiaBan;
            Hinh = s.AnhBia;

            SoLuongMua = sl;
        }
    }
    public class Giohang
    {
        public List<Item> lstSP;

        public Giohang()
        {
            lstSP=new List<Item>();
        }
        public void Them(int ms,int sl)
        {
            Item x =new Item(ms,sl);
            lstSP.Add(x);
        }
        public int DemSLMatHang()
        {
            return lstSP.Count;
        }
        public int TongSLSP()
        {
            return lstSP.Sum(x => x.SoLuongMua);
        }
        public void Xoa(int ms)
        {            
            lstSP.RemoveAt(ms);
        }
    }
}