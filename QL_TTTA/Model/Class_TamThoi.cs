using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_TTTA.Model
{
    public class Class_TamThoi
    {
    }
    public class PhongThi
    {
        public int MaPhong { get; set; }
        public int SoLuong { get; set; }
        public string TenPhong { get; set; }
        public DateTime? NgayThi { get; set; }
        public string TenTrinhDo { get; set; }
        public string KhoaThi { get; set; }
        public PhongThi(int x, string y) { MaPhong = x; TenPhong = y; }
    }
    public class GiaoVien
    {
        public int MaGV { get; set; }
        public string TenGiaoVien { get; set; }
        public string SDT { get; set; }

    }
    public class TrinhDo
    {
        public string TenTrinhDo { get; set; }

    }
    public class KhoaThi
    {
        public int MaKT { get; set; }
        public string TenKhoaThi { get; set; }
        public string NgayThi { get; set; }

    }
    public class ThiSinh
    {
        public int MaTS { get; set; }
        public string TenTS { get; set; }
        public string SDT { get; set; }
        public float DiemDoc, DiemNghe, DiemNoi, DiemViet;
        public ThiSinh(int x, string y, string z) { MaTS = x; TenTS = y; SDT = z; }

    }
}
