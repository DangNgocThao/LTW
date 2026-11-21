using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai1_Tuan2.Models
{
    public class PhongBan
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public PhongBan(string Ma ,string Ten)
        {
            this.Ma = Ma;
            this.Ten = Ten;
        }
    }
}