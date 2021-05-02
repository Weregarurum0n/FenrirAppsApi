using Dapper;
using JapaneseLearningApi.AccentTheme.RequestModels;
using JapaneseLearningApi.AccentTheme.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JapaneseLearningApi.AccentTheme.Repositories
{
    public class AccentThemeRepository : IAccentThemeRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly IRequestInfo _requestInfo;

        private static string p_Theme_Get = "p_Theme_Get";
        private static string p_Theme_Set = "p_Theme_Set";

        public AccentThemeRepository(IConnectionString connectionString, IRequestInfo requestInfo)
        {
            _connectionString = connectionString;
            _requestInfo = requestInfo;
        }

        public ApiResponse<List<Accent>> GetAllThemes()
        {
            return null;
        }

        public ApiResponse<Accent> GetSpecificTheme(int id)
        {
            return null;
        }

        public ReturnStatus SetTheme(SetAccent req)
        {
            return null;
        }

        public ApiResponse<List<Theme>> GetAllAccents()
        {
            return null;
        }

        public ApiResponse<Theme> GetSpecificAccents(int id)
        {
            return null;
        }

        public ReturnStatus SetTheme(SetTheme req)
        {
            return null;
        }
    }
}
