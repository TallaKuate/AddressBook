using Microservices.API.Gateways.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microservices.API.Gateways.Services
{

    public class AddressService : IAddressService
    {      

        IConfiguration _iconfiguration;
        private IApiService _apiService;

        public AddressService(IConfiguration iconfiguration,
            IApiService apiService)
        {
            _iconfiguration = iconfiguration;
            _apiService = apiService;

        }

        public async Task<Model.Address> GetAddressByIdAsync(int id)
        {
            var host = _iconfiguration.GetSection("ApplicationSettings")["ApiHostAddress"].ToString();
            var result = await _apiService.GetAsync<Model.Address>(host,
                UrlsConfig.AddressOperations.GetAddressById(id))
                .ConfigureAwait(false);
            return result;
        }
    }
}
