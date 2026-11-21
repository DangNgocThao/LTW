using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DangNgocThao_2001206904.Models
{
    public class Item
    {
        DataDataContext dl = new DataDataContext();

        public string IdSP { get; set; }
        public string TenSP { get; set; }
        public string Hinh { get; set; }
        public double DonGia { get; set; }
        public int SoLuongMua { get; set; }

        public Item(string id)
        {
            IdSP = id;
            NongSan ns = dl.NongSans.FirstOrDefault(t => t.idSP == id);
            TenSP = ns.TenSP;
            DonGia = (double)ns.DonGia;
            Hinh = ns.HinhDaiDien;

            SoLuongMua = 1;
        }

        public Item(string id,int sl)
        {
            IdSP = id;
            NongSan ns = dl.NongSans.FirstOrDefault(t => t.idSP == id);
            TenSP = ns.TenSP;
            DonGia = (double)ns.DonGia;
            Hinh = ns.HinhDaiDien;

            SoLuongMua = sl;
        }
    }
}