using Dapper;
using JapaneseLearningApi.Profile.RequestModels;
using JapaneseLearningApi.Profile.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JapaneseLearningApi.Profile.Repositories
{
    public interface IProfileRepository
    {
        ApiResponse<UserProfile> GetProfile(int id);
        ApiResponse<ReturnStatus> ChangePassword(SetPassword req);
        ReturnStatus SetAccentTheme(SetAccentTheme req);
    }
}
