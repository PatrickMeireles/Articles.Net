using Articles.Application.ViewModel;
using System.Threading.Tasks;

namespace Articles.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<UserViewModel> Authenticate(string email, string senha);

        Task<bool> Create(CreateUserViewModel model);

        Task<UserViewModel> GetByEmail(string email);

        Task<UserViewModel> GetByHash(string hash);
    }
}
