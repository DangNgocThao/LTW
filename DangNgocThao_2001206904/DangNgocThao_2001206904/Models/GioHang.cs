using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DangNgocThao_2001206904.Models
{
    public class GioHang
    {
        public List<Item> lstSP;

        public GioHang()
        {
            lstSP = new List<Item>();
        }
        public void Them(string IdSP, int sl)
        {
            Item x = new Item(IdSP, sl);
            lstSP.Add(x);
        }
        public int DemSLMatHang()
        {
            return lstSP.Count;
        }
        public double TongTien()
        {
            return lstSP.Sum(t => t.SoLuongMua * t.DonGia);
        }
        public int TongSLSP()
        {
            return lstSP.Sum(x => x.SoLuongMua);
        }
        public void Xoa(string id)
        {
            Item ns = lstSP.FirstOrDefault(t => t.IdSP == id);
            lstSP.Remove(ns);
        }
    }
}