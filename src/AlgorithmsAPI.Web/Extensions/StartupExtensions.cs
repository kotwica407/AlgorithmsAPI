using AlgorithmsAPI.Services.Cipher;
using AlgorithmsAPI.Services.Ranking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlgorithmsAPI.Web.Extensions
{
    internal static class StartupExtensions
    {
        internal static void ConfigureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ICipherService, CipherService>();
            services.AddScoped<IRankingService, RankingService>();

            services.ConfigureSwagger();
        }
    }
}