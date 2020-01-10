using Microservices.API.Gateways.Config;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microservices.API.Gateways.Services
{
    public class UserService : IUserService
    {
        IConfiguration _iconfiguration;
        private IApiService _apiService;

        public UserService(IConfiguration iconfiguration,
            IApiService apiService)
        {
            _iconfiguration = iconfiguration;
            _apiService = apiService;
        }
        public async Task<Model.DomainUser> GetUserByIdAsync(int id)
        {
            var host = _iconfiguration.GetSection("ApplicationSettings")["ApiHostUser"].ToString();
            var result = await _apiService.GetAsync<Model.DomainUser>(host,
                UrlsConfig.UserOperations.GetDomainUserById(id))
                .ConfigureAwait(false);
            return result;
        }
    }
}
