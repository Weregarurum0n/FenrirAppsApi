using JapaneseLearningApi.Profile.RequestModels;
using JapaneseLearningApi.Profile.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;

namespace JapaneseLearningApi.Profile.Services
{
    public interface IProfileService
    {
        ApiResponse<UserProfile> GetProfile(int id);
        ApiResponse<ReturnStatus> ChangePassword(SetPassword req);
        ReturnStatus SetAccentTheme(SetAccentTheme req);
    }
}
