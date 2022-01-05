using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Service
{
    public class TrinhDoRepository : EFRepository<TrinhDo>, ITrinhDoRepository
    {
        public TrinhDoRepository(CenterContext context) : base(context)
        {
        }
    }
}