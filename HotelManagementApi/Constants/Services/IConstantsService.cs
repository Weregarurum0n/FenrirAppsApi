using HotelManagementApi.Constants.RequestModels;
using HotelManagementApi.Constants.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Constants.Services
{
    public interface IConstantsService
    {
        ApiResponse<List<Constant>> GetConstants(GetConstants req);
        ReturnStatus SetConstant(SetConstant req);
    }
}
