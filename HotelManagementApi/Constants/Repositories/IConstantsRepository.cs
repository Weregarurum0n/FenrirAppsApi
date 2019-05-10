﻿using HotelManagementApi.Constants.RequestModels;
using HotelManagementApi.Constants.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Constants.Repositories
{
    public interface IConstantsRepository
    {
        List<Constant> GetConstants(GetConstants req);
        Constant GetConstant(int constantId);
        ReturnStatus SetConstant(SetConstant req);
    }
}