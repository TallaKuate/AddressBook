using System.Threading.Tasks;

namespace Microservices.API.Gateways.Services
{
    public interface IUserService
    {
        Task<Model.DomainUser> GetUserByIdAsync(int id);
    }
}
