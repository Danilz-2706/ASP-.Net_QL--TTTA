using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class KhoaThi
    {
        public string MaKhoaThi { get; set; }
        public string TenKhoaThi { get; set; }
        public DateTime NgayThi { get; set; }
        public ICollection<SoBaoDanh> SBDs { get; set; }
        public ICollection<PhongThi> PhongThis { get; set; }
    }
}
