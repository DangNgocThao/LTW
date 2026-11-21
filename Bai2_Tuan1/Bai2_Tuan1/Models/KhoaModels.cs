using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai2_Tuan1.Models
{
    public class KhoaModels
    {
        public String TenKhoa { get; set; }
        public int NamThanhLap { get; set; }
        public String Message { get; set; }

        public KhoaModels()
        {
            TenKhoa = "Khoa Công Nghệ Thông Tin";
            NamThanhLap = 2003;
            Message = "Chào mừng các bạn đến với FIT-HUFI";
        }
    }
}