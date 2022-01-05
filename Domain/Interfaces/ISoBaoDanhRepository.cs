using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ISoBaoDanhRepository : IEFRepository<SoBaoDanh>
    {
        public SoBaoDanh Find(string CMND);
        public SoBaoDanh GetByEager(string SBD);
    }
}
