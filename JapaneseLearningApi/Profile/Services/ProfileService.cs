using JapaneseLearningApi.Profile.Repositories;
using JapaneseLearningApi.Profile.RequestModels;
using JapaneseLearningApi.Profile.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;

namespace JapaneseLearningApi.Profile.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _repository;

        public ProfileService(IProfileRepository repository) => _repository = repository;

        public ApiResponse<UserProfile> GetProfile(int id) => _repository.GetProfile(id);
        public ApiResponse<ReturnStatus> ChangePassword(SetPassword req) => _repository.ChangePassword(req);
        public ReturnStatus SetAccentTheme(SetAccentTheme req) => _repository.SetAccentTheme(req);
    }
}
