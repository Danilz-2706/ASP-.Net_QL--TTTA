using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Service
{
    public class ThamGiaDuThiRepository : EFRepository<ThamGiaDuThi>, IThamGiaDuThiRepository
    {
        public ThamGiaDuThiRepository(CenterContext context) : base(context)
        {
        }
    }
}