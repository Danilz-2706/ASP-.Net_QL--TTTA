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
    }
}