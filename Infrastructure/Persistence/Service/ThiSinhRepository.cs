using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Service
{
    public class ThiSinhRepository : EFRepository<ThiSinh>, IThiSinhRepository
    {
        public ThiSinhRepository(CenterContext context) : base(context)
        {
        }

        public ThiSinh Find(string sdt,string hoTen)
        {
            if(sdt != null && hoTen == null)
            {
                var ts = context.ThiSinhs.Where(x => x.SDT.Equals(sdt)).FirstOrDefault();
                return ts;
            }
            if(sdt == null && hoTen != null)
            {
                var ts = context.ThiSinhs.Where(x => x.HoTen.Equals(hoTen)).FirstOrDefault();
            }
            
            return context.ThiSinhs.Where(x => x.SDT.Equals(sdt) && x.HoTen.Equals(hoTen)).FirstOrDefault();
        }
    }
}