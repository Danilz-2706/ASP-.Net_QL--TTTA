using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CanhThi
    {
        public GiaoVien GiaoVien { get; set; }
        public int MaGV { get; set; }
        public PhongThi PhongThi { get; set; }
        public string MaPhongThi { get; set; }
    }
}
