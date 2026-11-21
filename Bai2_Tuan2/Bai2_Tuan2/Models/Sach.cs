using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai2_Tuan2.Models
{
    public class Sach
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public double Gia { get; set; }
        public string Anh { get; set; }
        public string TacGia { get; set; }
        public string MoTa { get; set; }

        public Sach(string Ma, string Ten, double Gia, string Anh, string TacGia, string MoTa)
        {
            this.Ma = Ma;
            this.Ten = Ten;
            this.Gia = Gia;
            this.Anh = Anh;
            this.TacGia = TacGia;
            this.MoTa = MoTa;
        }
    }
}