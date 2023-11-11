namespace TestMaker.Evaluation.Application.Interfaces
{
    public interface ICacheService
    {
        Task AddAsync(string key, string data, int timeoutInSeconds);
        Task<T?> GetAsync<T>(string key);
        Task<T?> GetAsync<T>(string key, Func<Task<T>> valueFactory, int timeoutInSeconds);
    }
}
