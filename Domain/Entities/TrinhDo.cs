using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TrinhDo
    {
        public string MaTrinhDo { get; set; }
        public string TenTrinhDo { get; set; }
        public ICollection<SoBaoDanh> SBDs { get; set; }
        public ICollection<PhongThi> PhongThis { get; set; }
    }
}
