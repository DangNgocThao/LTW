using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Thao_DangNgoc_2001206904_KT1.Models
{
    public class DuLieu
    {
        public List<LoaiSP> listLoai = new List<LoaiSP>();
        public List<sanpham> listsp = new List<sanpham>();
        public DuLieu()
        {
            string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            string strsel = "Select * from LoaiSP";
            SqlDataAdapter da = new SqlDataAdapter(strsel, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                LoaiSP c = new LoaiSP();
                c.maloai = item["maLoai"].ToString();
                c.tenloai = item["tenLoai"].ToString();
                listLoai.Add(c); 
            }

            string strsel1 = "Select * from sanpham";
            SqlDataAdapter da1 = new SqlDataAdapter(strsel1, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow item in dt1.Rows)
            {
                sanpham c = new sanpham();
                c.masp = item["masp"].ToString();
                c.tensp = item["tensp"].ToString();
                c.gia = double.Parse(item["gia"].ToString());
                c.dactinh = item["DacTinh"].ToString();
                c.chatlieu = item["chatLieu"].ToString();
                c.xuatxu = item["xuatXu"].ToString();
                c.loaisp = item["loaisp"].ToString();
                c.hinh = item["HinhDaiDien"].ToString();
                c.size = item["Size"].ToString();
                listsp.Add(c);
            }
        }
    }
}