using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SoBaoDanh
    {
        public string SBD { get; set; }
        public ThiSinh ThiSinh { get; set; }
        public string CMND { get; set; }
        public KhoaThi KhoaThi { get; set; }
        public string MaKhoaThi { get; set; }
        public TrinhDo TrinhDo { get; set; }
        public string MaTrinhDo { get; set; }
        public ICollection<PhongThi> PhongThis { get; set; }
        public ICollection<ThamGiaDuThi> ThamGiaDuThis { get; set; }
    }
}
