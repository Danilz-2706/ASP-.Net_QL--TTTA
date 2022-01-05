using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IThiSinhRepository:IEFRepository<ThiSinh>
    {
        public ThiSinh Find(string sdt, string hoTen);
    }
}
