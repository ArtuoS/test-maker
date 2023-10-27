namespace TestMaker.Evaluation.Application.Interfaces
{
    public interface ICacheService
    {
        void Add(string key, object data, int timeoutInSeconds);
        bool Get<T>(string key, out T? value);
    }
}
