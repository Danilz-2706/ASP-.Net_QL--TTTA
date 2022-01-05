using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GiaoVien
    {
        public int MaGV { get; set; }
        public string HoTen { get; set; }
        public Gender GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public ICollection<PhongThi> PhongThis { get; set; }
        public ICollection<CanhThi> CanhThis { get; set; }
    }
}
