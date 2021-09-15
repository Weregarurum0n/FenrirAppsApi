using JapaneseLearningApi.Profile.RequestModels;
using JapaneseLearningApi.Profile.ResponseModels;
using JapaneseLearningApi.Shared;

namespace JapaneseLearningApi.Profile.Services
{
    public interface IProfileService
    {
        ReturnStatus Login(GetLogin req);
        ApiResponse<UserProfile> GetProfile();
        ReturnStatus ChangePassword(SetPassword req);
        ApiResponse<AccentTheme> GetAccentTheme();
        ReturnStatus SetAccentTheme(SetAccentTheme req);
    }
}
