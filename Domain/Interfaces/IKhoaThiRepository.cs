﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IKhoaThiRepository : IEFRepository<KhoaThi>
    {
        public int CountTSByKhoa(string khoaThi,string trinhDo);
    }
}
