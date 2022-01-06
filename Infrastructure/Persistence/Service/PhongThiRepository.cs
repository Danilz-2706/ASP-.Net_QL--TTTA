using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Service
{
    public class PhongThiRepository : EFRepository<PhongThi>, IPhongThiRepository
    {
        public PhongThiRepository(CenterContext context) : base(context)
        {
        }
        public override IEnumerable<PhongThi> GetAll()
        {
            return context.PhongThis.Include(x => x.SoBaoDanhs).ThenInclude(x => x.ThiSinh).ToList();
        }

        public IEnumerable<ThiSinh> GetTSByPhong(string maPhong)
        {
            var list = (from tg in context.ThamGiaDuThis
                        where tg.MaPhongThi.Equals(maPhong)
                        from sbd in context.SoBaoDanhs
                        where sbd.SBD.Equals(tg.SBD)
                        from ts in context.ThiSinhs
                        where ts.CMND.Equals(sbd.CMND)
                        select new ThiSinh
                        {
                            CMND = ts.CMND,
                            HoTen = ts.HoTen,
                            NoiSinh = ts.NoiSinh,
                            GioiTinh = ts.GioiTinh,
                            NgaySinh = ts.NgaySinh,
                            SDT = ts.SDT,
                            NoiCap = ts.NoiCap,
                            NgayCap = ts.NgayCap,
                            Email = ts.Email,
                            SoBaoDanh = sbd.SBD
                        }
                            ).ToList();
            return list;
        }

        public IEnumerable<GiaoVien> GetGVByPhong(string maPhong)
        {
            var list = (from ct in context.CanhThis
                        where ct.MaPhongThi.Equals(maPhong)
                        from gv in context.GiaoViens
                        where gv.MaGV.Equals(ct.MaGV)
                        from pt in context.PhongThis
                        where pt.MaPhongThi.Equals(ct.MaPhongThi)
                        select new GiaoVien
                        {
                            MaGV = gv.MaGV,
                            HoTen = gv.HoTen,
                            SDT = gv.SDT,
                            Email = gv.Email
                        }
                            ).ToList();
            return list;
        }

    }
}