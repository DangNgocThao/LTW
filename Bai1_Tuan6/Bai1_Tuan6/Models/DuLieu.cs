using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Bai1_Tuan6.Models
{
    public class DuLieu
    {
        public List<Category> listTheLoai = new List<Category>();
        public List<SanPham> listSanPham = new List<SanPham>();
        public DuLieu()
        {
            string strcon = "Data Source = LAPTOP-HP348G7; database = QL_DTDD1; Integrated Security = true";
            SqlConnection con = new SqlConnection(strcon);
            string strsel = "Select * from Loai";
            SqlDataAdapter da = new SqlDataAdapter(strsel, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                Category c = new Category();
                c.maloai = item["MaLoai"].ToString();
                c.tenloai = item["TenLoai"].ToString();
                listTheLoai.Add(c);
            }

            string strsel1 = "Select * from SanPham,Loai where SanPham.MaLoai = Loai.MaLoai";
            SqlDataAdapter da1 = new SqlDataAdapter(strsel1, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow item in dt1.Rows)
            {
                SanPham c = new SanPham();
                c.masp = item["MaSP"].ToString();
                c.tensp = item["TenSP"].ToString();
                c.duongdan = item["DuongDan"].ToString();
                c.gia = double.Parse(item["Gia"].ToString());
                c.mota = item["MoTa"].ToString();
                c.maloai = item["MaLoai"].ToString();
                listSanPham.Add(c);
            }
        }
    }
}