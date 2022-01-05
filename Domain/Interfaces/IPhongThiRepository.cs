using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IPhongThiRepository : IEFRepository<PhongThi>
    {
        public IEnumerable<ThiSinh> GetTSByPhong(string maPhong);
    }
}
