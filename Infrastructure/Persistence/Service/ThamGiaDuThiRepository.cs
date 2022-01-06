using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Service
{
    public class ThamGiaDuThiRepository : EFRepository<ThamGiaDuThi>, IThamGiaDuThiRepository
    {
        public ThamGiaDuThiRepository(CenterContext context) : base(context)
        {
        }

        public override void Update(ThamGiaDuThi entity, int id)
        {
            ThamGiaDuThi exist = context.Set<ThamGiaDuThi>().Find(id);
            context.Entry(exist).State = EntityState.Detached;
            context.Entry(exist).CurrentValues.SetValues(entity);
            context.Entry(exist).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}