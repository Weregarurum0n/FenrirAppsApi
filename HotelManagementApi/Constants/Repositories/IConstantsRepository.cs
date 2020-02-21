using HotelManagementApi.Constants.RequestModels;
using HotelManagementApi.Constants.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Constants.Repositories
{
    public interface IConstantsRepository
    {
        ApiResponse<List<Constant>> GetConstants(GetConstants req);
        ReturnStatus SetConstant(SetConstant req);
    }
}
