using System.Threading.Tasks;

namespace Microservices.API.Gateways.Services
{
    public interface IAddressService
    {
        Task<Model.Address> GetAddressByIdAsync(int id);
    }
}
