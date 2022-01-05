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
    }
}