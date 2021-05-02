using AnimeCharacterBirthdayApi.DataParse.ResponseModels;
using AnimeCharacterBirthdayApi.Shared;
using System.Collections.Generic;

namespace AnimeCharacterBirthdayApi.DataParse.Services
{
    public interface IDataParseService
    {
        ApiResponse<List<Character>> GetCharacterList();
        ApiResponse<List<Character>> GetCharacterList(int date, string month);
        string GetCharacterHTML(int date, Months month);
    }
}
