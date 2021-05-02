using Dapper;
using JapaneseLearningApi.AccentTheme.RequestModels;
using JapaneseLearningApi.AccentTheme.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JapaneseLearningApi.AccentTheme.Repositories
{
    public interface IAccentThemeRepository
    {
        ApiResponse<List<Accent>> GetAllThemes();
        ApiResponse<Accent> GetSpecificTheme(int id);
        ReturnStatus SetTheme(SetAccent req);

        ApiResponse<List<Theme>> GetAllAccents();
        ApiResponse<Theme> GetSpecificAccents(int id);
        ReturnStatus SetTheme(SetTheme req);
    }
}
