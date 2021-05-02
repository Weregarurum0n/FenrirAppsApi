using JapaneseLearningApi.AccentTheme.Repositories;
using JapaneseLearningApi.AccentTheme.RequestModels;
using JapaneseLearningApi.AccentTheme.ResponseModels;
using JapaneseLearningApi.Shared;
using System.Collections.Generic;

namespace JapaneseLearningApi.AccentTheme.Services
{
    public class AccentThemeService : IAccentThemeService
    {
        private readonly IAccentThemeRepository _repository;

        public AccentThemeService(IAccentThemeRepository repository) => _repository = repository;

        public ApiResponse<List<Accent>> GetAllThemes() => _repository.GetAllThemes();

        public ApiResponse<Accent> GetSpecificTheme(int id) => _repository.GetSpecificTheme(id);

        public ReturnStatus SetTheme(SetAccent req) => _repository.SetTheme(req);
        

        public ApiResponse<List<Theme>> GetAllAccents() => _repository.GetAllAccents();

        public ApiResponse<Theme> GetSpecificAccents(int id) => _repository.GetSpecificAccents(id);

        public ReturnStatus SetTheme(SetTheme req) => _repository.SetTheme(req);
    }
}
