using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DangNgocThao_2001206904_KT2.Models
{
    public class Item
    {
        DataDataContext dl = new DataDataContext();
        public int ma { get; set; }
        public string ten { get; set; }
        public string ngaydi { get; set; }
        public double dongia { get; set; }
        public int soluong { get; set; }

        public Item(int id)
        {
            ma = id;
            Tour t = dl.Tours.FirstOrDefault(a => a.MaTour == id);
            ten = t.TenTour;
            ngaydi = t.NgayDi.ToString();
            dongia = (double)t.GiaVe;
            soluong = 1;
        }
        public Item(int id ,int sl)
        {
            ma = id;
            Tour t = dl.Tours.FirstOrDefault(a => a.MaTour == id);
            ten = t.TenTour;
            ngaydi = t.NgayDi.ToString();
            dongia = (double)t.GiaVe;
            soluong = sl;
        }
    }
}