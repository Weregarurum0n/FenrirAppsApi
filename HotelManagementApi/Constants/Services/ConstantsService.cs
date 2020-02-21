using HotelManagementApi.Constants.Repositories;
using HotelManagementApi.Constants.RequestModels;
using HotelManagementApi.Constants.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Constants.Services
{
    public class ConstantsService : IConstantsService
    {
        private readonly IConstantsRepository _repository;

        public ConstantsService(IConstantsRepository repository) => _repository = repository;

        public ApiResponse<List<Constant>> GetConstants(GetConstants req) => _repository.GetConstants(req);
        public ReturnStatus SetConstant(SetConstant req) => _repository.SetConstant(req);
    }
}
