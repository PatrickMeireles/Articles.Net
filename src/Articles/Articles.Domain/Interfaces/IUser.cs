using Articles.Domain.Interfaces.Generic;
using Articles.Entities;
using System.Threading.Tasks;

namespace Articles.Domain.Interfaces
{
    public interface IUser : IRepository<User>
    {
        Task<User> Authenticate(string email, string password);
        Task<User> GetByEmail(string email);

        Task<User> GetByHash(string hash);
    }
}
