using Newtonsoft.Json;
using StackExchange.Redis;
using TestMaker.Evaluation.Application.Interfaces;

namespace TestMaker.Evaluation.Application.Services
{
    public class CacheService : ICacheService
    {
        private ConfigurationOptions _configurationOptions = new ConfigurationOptions
        {
            EndPoints = { Environment.GetEnvironmentVariable("redis_connection_string") },
            Password = "redispw",
            AbortOnConnectFail = false,
        };

        public async Task AddAsync(string key, string data, int timeoutInSeconds)
        {
            using (var redis = ConnectionMultiplexer.Connect(_configurationOptions))
            {
                var db = redis.GetDatabase();
                await db.StringSetAsync(key, data, TimeSpan.FromSeconds(timeoutInSeconds));
            };
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            using (var redis = ConnectionMultiplexer.Connect(_configurationOptions))
            {
                var db = redis.GetDatabase();
                var data = await db.StringGetAsync(key);
                return (data.HasValue) ? JsonConvert.DeserializeObject<T>(data) : default;
            };
        }


        public async Task<T?> GetAsync<T>(string key, Func<Task<T>> valueFactory, int timeoutInSeconds)
        {
            using (var redis = ConnectionMultiplexer.Connect(_configurationOptions))
            {
                var db = redis.GetDatabase();
                var cachedValue = await db.StringGetAsync(key);
                if (!cachedValue.IsNull)
                {
                    return JsonConvert.DeserializeObject<T>(cachedValue);
                }

                var newValue = await valueFactory();
                await db.StringSetAsync(key, JsonConvert.SerializeObject(newValue), TimeSpan.FromSeconds(timeoutInSeconds));
                return newValue;
            };
        }
    }
}
