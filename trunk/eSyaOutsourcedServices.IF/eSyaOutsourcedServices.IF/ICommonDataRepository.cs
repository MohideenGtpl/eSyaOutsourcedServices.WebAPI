﻿using eSyaOutsourcedServices.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaOutsourcedServices.IF
{
   public interface ICommonDataRepository
    {
        Task<List<DO_BusinessLocation>> GetBusinessKey();
    }
}
