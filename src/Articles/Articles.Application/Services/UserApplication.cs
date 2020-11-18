using Articles.Application.Interfaces;
using Articles.Application.ViewModel;
using Articles.Domain.Interfaces;
using Articles.Entities;
using Articles.Entities.Enuns;
using Articles.Util;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Articles.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUser _user;
        private readonly IMapper _mapper;

        public UserApplication(IUser user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Authenticate(string email, string senha) => 
                _mapper.Map<UserViewModel>(await _user.Authenticate(email, senha));

        public async Task<bool> Create(CreateUserViewModel model)
        {
            var user = new User();

            user.Name = "Admin";
            user.Email = model.Email;
            user.Hash = HashMD5.getMD5(model.Email + model.Password + DateTime.Now);
            user.Password = HashMD5.getMD5(model.Password);
            user.Role = (int)RoleType.Admin;

            await _user.Add(user);

            return true;
        }

        public async Task<UserViewModel> GetByEmail(string email) => 
                _mapper.Map<UserViewModel>(await _user.GetByEmail(email));

        public async Task<UserViewModel> GetByHash(string hash) =>
                _mapper.Map<UserViewModel>(await _user.GetByHash(hash));
    }
}
