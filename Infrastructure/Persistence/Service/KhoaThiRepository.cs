using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Service
{
    public class KhoaThiRepository : EFRepository<KhoaThi>, IKhoaThiRepository
    {
        public KhoaThiRepository(CenterContext context) : base(context)
        {
        }

        public int CountTSByKhoa(string khoaThi,string trinhDo)
        {
            var count = (from p in context.PhongThis
                       where p.MaKhoaThi.Equals(khoaThi) && p.MaTrinhDo.StartsWith(trinhDo)
                         from tg in context.ThamGiaDuThis
                       where tg.MaPhongThi.Equals(p.MaPhongThi)
                       select tg.MaPhongThi
                       ).Count();
            return count;
        }
    }
}