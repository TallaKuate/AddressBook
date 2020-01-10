using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.API.Gateways.Services
{
    public interface IAddressBookService
    {
        Task<List<Model.CountryAddressBook>> GetAddressBookAsync();
    }
}
