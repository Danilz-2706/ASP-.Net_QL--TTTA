using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Service
{
    public class CanhThiRepository : EFRepository<CanhThi>, ICanhThiRepository
    {
        public CanhThiRepository(CenterContext context) : base(context)
        {
        }
    }
}