using Dapper;
using JapaneseLearningApi.Profile.RequestModels;
using JapaneseLearningApi.Profile.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JapaneseLearningApi.Profile.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_Profile_Get = "p_Profile_Get";
        private static string p_Password_Set = "p_Password_Set";
        private static string p_AccentTheme_Set = "p_AccentTheme_Set";

        public ProfileRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public ApiResponse<UserProfile> GetProfile(int id)
        {
            return null;
        }
        public ApiResponse<ReturnStatus> ChangePassword(SetPassword req)
        {
            return null;
        }
        public ReturnStatus SetAccentTheme(SetAccentTheme req)
        {
            return null;
        }
    }
}
