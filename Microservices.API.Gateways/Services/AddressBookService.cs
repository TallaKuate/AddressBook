using Microservices.API.Gateways.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static Microservices.API.Gateways.Config.UrlsConfig;

namespace Microservices.API.Gateways.Services
{
    public class AddressBookService : IAddressBookService
    {
        IConfiguration _iconfiguration;
        private IApiService _apiService;

        public AddressBookService(IConfiguration iconfiguration,
            IApiService apiService)
        {
            _iconfiguration = iconfiguration;
            _apiService = apiService;

        }
        public async Task<List<Model.CountryAddressBook>> GetAddressBookAsync()
        {
            var host = _iconfiguration.GetSection("ApplicationSettings")["ApiHostAddressBook"].ToString();
            var result = await _apiService.GetAsync<List<Model.CountryAddressBook>>(host,
                UrlsConfig.AddressBookOperations.GetAddressBook())
                .ConfigureAwait(false);
            return result; 

        }
    }
}
