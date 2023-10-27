using Microsoft.Extensions.Caching.Memory;
using TestMaker.Evaluation.Application.Interfaces;

namespace TestMaker.Evaluation.Application.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;
        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Add(string key, object data, int timeoutInSeconds)
        {
            _cache.GetOrCreate(key, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(timeoutInSeconds);
                return data;
            });
        }

        public bool Get<T>(string key, out T? value)
        {
            return _cache.TryGetValue(key, out value);
        }
    }
}
