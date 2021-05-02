using JapaneseLearningApi.AccentTheme.Repositories;
using JapaneseLearningApi.AccentTheme.Services;
using JapaneseLearningApi.Hiragana.Repositories;
using JapaneseLearningApi.Hiragana.Services;
using JapaneseLearningApi.Kanji.Repositories;
using JapaneseLearningApi.Kanji.Services;
using JapaneseLearningApi.Katakana.Repositories;
using JapaneseLearningApi.Katakana.Services;
using JapaneseLearningApi.Ping;
using JapaneseLearningApi.Profile.Repositories;
using JapaneseLearningApi.Profile.Services;
using JapaneseLearningApi.Vocab.Repositories;
using JapaneseLearningApi.Vocab.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JapaneseLearningApi
{
    public static class JapaneseLearningIoc
    {
        public static IServiceCollection RegisterHotelManagementDependencies(this IServiceCollection services)
        {
            services.AddTransient<IAccentThemeService, AccentThemeService>();
            services.AddTransient<IAccentThemeRepository, AccentThemeRepository>();

            services.AddTransient<IHiraganaService, HiraganaService>();
            services.AddTransient<IHiraganaRepository, HiraganaRepository>();

            services.AddTransient<IKanjiService, KanjiService>();
            services.AddTransient<IKanjiRepository, KanjiRepository>();

            services.AddTransient<IKatakanaService, KatakanaService>();
            services.AddTransient<IKatakanaRepository, KatakanaRepository>();

            services.AddTransient<IPingJapaneseLearning, PingJapaneseLearning>();

            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IProfileRepository, ProfileRepository>();

            services.AddTransient<IVocabService, VocabService>();
            services.AddTransient<IVocabRepository, VocabRepository>();

            return services;
        }
    }
}
