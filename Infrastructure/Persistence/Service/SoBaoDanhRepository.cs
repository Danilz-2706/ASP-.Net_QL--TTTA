using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Service
{
    public class SoBaoDanhRepository : EFRepository<SoBaoDanh>, ISoBaoDanhRepository
    {
        public SoBaoDanhRepository(CenterContext context) : base(context)
        {
        }

        public SoBaoDanh Find(string CMND)
        {
            var sbd = context.SoBaoDanhs.Where(x => x.CMND.Equals(CMND)).FirstOrDefault();
            if (sbd != null)
                return sbd;
            return null;
        }

        public SoBaoDanh GetByEager(string SBD)
        {
            var sbd = context.SoBaoDanhs.Include(x => x.ThiSinh).Where(x => x.SBD.Equals(SBD)).FirstOrDefault();
            return sbd;
        }
    }
}