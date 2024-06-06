
using RedisLearn.Configuration;
using RedisLearn.Services;
using StackExchange.Redis;

namespace RedisLearn.Installer
{
    public class CacheInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var redisConfiguration = new RedisConfiguration();

            configuration.GetSection("RedisConfiguration").Bind(redisConfiguration);

            services.AddSingleton(redisConfiguration);

            if (!redisConfiguration.Enabled) return;

            services.AddSingleton<IConnectionMultiplexer>(x => ConnectionMultiplexer.Connect(redisConfiguration.ConnectionString));
            services.AddStackExchangeRedisCache(option => option.Configuration = redisConfiguration.ConnectionString);

            services.AddSingleton<IResponseCacheServices, ResponseCacheServices>();
        }
    }
}
