using JapaneseLearningApi.Profile.Repositories;
using JapaneseLearningApi.Profile.RequestModels;
using JapaneseLearningApi.Profile.ResponseModels;
using JapaneseLearningApi.Shared;

namespace JapaneseLearningApi.Profile.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _repository;

        public ProfileService(IProfileRepository repository) => _repository = repository;

        public ReturnStatus Login(GetLogin req) => _repository.Login(req);
        public ApiResponse<UserProfile> GetProfile() => _repository.GetProfile();
        public ReturnStatus ChangePassword(SetPassword req) => _repository.ChangePassword(req);
        public ApiResponse<AccentTheme> GetAccentTheme() => _repository.GetAccentTheme();
        public ReturnStatus SetAccentTheme(SetAccentTheme req) => _repository.SetAccentTheme(req);
    }
}
