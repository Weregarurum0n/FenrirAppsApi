using HotelManagementApi.Constants.RequestModels;
using HotelManagementApi.Constants.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Constants.Services
{
    public interface IConstantsService
    {
        List<Constant> GetConstants(GetConstants req);
        Constant GetConstant(int constantId);
        ResponseStatus SetConstant(SetConstant req);
    }
}
