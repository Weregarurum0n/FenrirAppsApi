using AnimeCharacterBirthdayApi.DataParse.Services;
using AnimeCharacterBirthdayApi.Ping;
using Microsoft.Extensions.DependencyInjection;
using Unity;

namespace AnimeCharacterBirthdayApi
{
    public static class AnimeCharacterBirthdayIoc
    {
        public static IServiceCollection RegisterAnimeCharacterBirthdayDependencies(this IServiceCollection services)
        {
            services.AddTransient<IDataParseService, DataParseService>();

            services.AddTransient<IPingAnimeCharacterBirthday, PingAnimeCharacterBirthday>();

            return services;
        }
    }
}
