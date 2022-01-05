using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PhongThi
    {
        public string MaPhongThi { get; set; }
        public string TenPhong { get; set; }
        public TrinhDo TrinhDo { get; set; }
        public string MaTrinhDo { get; set; }
        public KhoaThi KhoaThi { get; set; }
        public string MaKhoaThi { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public ICollection<SoBaoDanh> SoBaoDanhs { get; set; }
        public ICollection<ThamGiaDuThi> ThamGiaDuThis { get; set; }
        public ICollection<GiaoVien> GiaoViens { get; set; }
        public ICollection<CanhThi> CanhThis { get; set; }
    }
}
