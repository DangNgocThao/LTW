using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DangNgocThao_2001206904_KT2.Models
{
    public class GioHang
    {
        public List<Item> lst;
        public GioHang()
        {
            lst = new List<Item>();
        }
        public void them(int id, int sl)
        {
            Item x = new Item(id, sl);
            lst.Add(x);
        }
        public int demslmathang()
        {
            return lst.Count;
        }
        public double tongtien()
        {
            return lst.Sum(t => t.soluong * t.dongia);
        }
        public int tongslsp()
        {
            return lst.Sum(x => x.soluong);
        }
        public void xoa(int id)
        {
            Item i = lst.FirstOrDefault(t => t.ma == id);
            lst.Remove(i);
        }
    }
}