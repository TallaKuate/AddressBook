using System.Threading.Tasks;

namespace Microservices.API.Gateways.Services
{
    public interface IApiService 
    {
        Task<T> GetAsync<T>(string serviceUrl, string relativePath);
    }
}
