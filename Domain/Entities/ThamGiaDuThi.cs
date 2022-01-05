using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ThamGiaDuThi
    {
        public SoBaoDanh SoBaoDanh { get; set; }
        public string SBD { get; set; }
        public PhongThi PhongThi { get; set; }
        public string MaPhongThi { get; set; }
        public int? Nghe { get; set; }
        public int? Noi { get; set; }
        public int? Doc { get; set; }
        public int? Viet { get; set; }
    }
}
