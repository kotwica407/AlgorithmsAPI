using AlgorithmsAPI.Services.Cipher;
using AlgorithmsAPI.Services.Ranking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlgorithmsAPI.Web.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ICipherService, CipherService>();
            services.AddScoped<IRankingService, RankingService>();
        }
    }
}