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

        public ConstantsService() => _repository = new ConstantsRepository();

        public List<Constant> GetConstants(GetConstants req) => _repository.GetConstants(req);
        public Constant GetConstant(int constantId) => _repository.GetConstant(constantId);
        public ReturnStatus SetConstant(SetConstant req) => _repository.SetConstant(req);
    }
}
