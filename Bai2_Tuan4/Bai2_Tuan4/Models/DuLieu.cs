using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Bai2_Tuan4.Models
{
    public class DuLieu
    {
        public List<Employee> dsNV = new List<Employee>();
        public DuLieu()
        {
            string strcon = "Data Source=LAPTOP-HP348G7;database=QL_NhanSu;Integrated Security=true";
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_Employee", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                var em = new Employee();
                em.ma = item["Id"].ToString();
                em.ten = item["Name"].ToString();
                em.gioitinh = item["Gender"].ToString();
                em.tinh = item["City"].ToString();
                dsNV.Add(em);
            }
        }
        public int getSL()
        {
            return dsNV.Count;
        }
    }
}