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
    }
}